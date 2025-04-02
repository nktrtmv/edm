using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Enrichers.Sources.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources.Generics.SingleKey;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Enrichers.Sources;

internal sealed class ApprovalReferenceEnricherSource
    : SingleKeyEnricherSourceGeneric<
        IApprovalReferencesClient,
        ApprovalReferenceEnricherKey,
        ApprovalReferenceValueExternal[]>
{
    public ApprovalReferenceEnricherSource(
        IApprovalReferencesClient client,
        ILogger<ApprovalReferenceEnricherSource> logger)
        : base(client, logger)
    {
    }

    protected override async Task<Dictionary<ApprovalReferenceEnricherKey, ApprovalReferenceValueExternal[]>> GetValues(
        ApprovalReferenceEnricherKey[] keys,
        CancellationToken cancellationToken)
    {
        var queries = GroupByReferenceKey(keys);

        SearchResult[] results = await GetResults(queries, cancellationToken);

        Dictionary<ApprovalReferenceEnricherKey, ApprovalReferenceValueExternal[]> result = UngroupByKey(keys, results);

        return result;
    }

    private static ApprovalReferenceEnricherKey[] GroupByReferenceKey(ApprovalReferenceEnricherKey[] keys)
    {
        var result = keys
            .GroupBy(k => k.ReferenceKey)
            .Select(g => new ApprovalReferenceEnricherKey(g.Key, g.SelectMany(k => k.Ids).Distinct().ToArray()))
            .ToArray();

        return result;
    }

    private static Dictionary<ApprovalReferenceEnricherKey, ApprovalReferenceValueExternal[]> UngroupByKey(
        ApprovalReferenceEnricherKey[] keys,
        SearchResult[] results)
    {
        var resultsByReferenceKey =
            results.ToDictionary(r => r.Key, r => r.Values.ToDictionary(v => v.Id));

        var result = new Dictionary<ApprovalReferenceEnricherKey, ApprovalReferenceValueExternal[]>();

        foreach (var key in keys)
        {
            Dictionary<string, ApprovalReferenceValueExternal>? valuesById = resultsByReferenceKey.GetValueOrDefault(key.ReferenceKey);

            if (valuesById is null)
            {
                continue;
            }

            ApprovalReferenceValueExternal[] values = key.Ids
                .Select(valuesById.GetValueOrDefault)
                .OfType<ApprovalReferenceValueExternal>()
                .ToArray();

            result.Add(key, values);
        }

        return result;
    }

    private async Task<SearchResult[]> GetResults(ApprovalReferenceEnricherKey[] keys, CancellationToken cancellationToken)
    {
        var tasks = keys
            .Select(k => GetResults(k, cancellationToken))
            .ToArray();

        SearchResult[] result = await Task.WhenAll(tasks);

        return result;
    }

    private async Task<SearchResult> GetResults(ApprovalReferenceEnricherKey key, CancellationToken cancellationToken)
    {
        var request = new SearchValuesApprovalReferencesQueryExternal(key.ReferenceKey, key.Ids, string.Empty, 0, int.MaxValue);

        var response = await Client.SearchValues(request, cancellationToken);

        var result = new SearchResult(key.ReferenceKey, response.Values);

        return result;
    }

    private sealed record SearchResult(ApprovalReferenceKeyExternal Key, ApprovalReferenceValueExternal[] Values);
}
