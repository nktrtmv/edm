using System.Collections.Concurrent;

using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Sources.Generics.SingleKey;

using Microsoft.Extensions.Logging;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Enrichers.
    References;

public sealed class ReferenceValueEnricherSource(
    ReferencesService.ReferencesServiceClient client,
    ILogger<ReferenceValueEnricherSource> logger)
    : SingleKeyEnricherSourceGeneric<ReferencesService.ReferencesServiceClient, ReferenceValueEnricherKey, ReferenceValueDto>(client, logger)
{
    protected override async Task<Dictionary<ReferenceValueEnricherKey, ReferenceValueDto>> GetValues(
        ReferenceValueEnricherKey[] keys,
        CancellationToken cancellationToken)
    {
        ReferenceIdByType[] referencesIdByType =
            keys.GroupBy(k => (k.TemplateId, k.ReferenceTypeId))
                .Select(g => new ReferenceIdByType(g.Key.TemplateId, g.Key.ReferenceTypeId, g.Select(v => v.Id).ToArray()))
                .ToArray();

        var valuesByType = new ConcurrentBag<(ReferenceIdByType ByType, ReferenceValueDto[] Values)>();

        await Parallel.ForEachAsync(
            referencesIdByType,
            cancellationToken,
            async (referenceId, token) =>
            {
                ReferenceValueDto[] searchValue = await SearchValue(referenceId, token);

                valuesByType.Add((referenceId, searchValue));
            });

        Dictionary<ReferenceValueEnricherKey, ReferenceValueDto> result = valuesByType
            .SelectMany(t => t.Values.Select(v => (t.ByType, v)))
            .ToDictionary(
                key => keys.Single(k => k.Id == key.v.Id && k.TemplateId == key.ByType.TemplateId && k.ReferenceTypeId == key.ByType.ReferenceTypeId),
                key => key.v);

        return result;
    }

    private async Task<ReferenceValueDto[]> SearchValue(ReferenceIdByType value, CancellationToken cancellationToken)
    {
        GetReferenceValuesSearchQuery query = ReferenceValueEnricherKeyConverter.ToQuery(value.TemplateId, value.ReferenceTypeId, value.Ids);

        GetReferenceValuesSearchQueryResponse response = await Client.GetReferenceValuesSearchAsync(query, cancellationToken: cancellationToken);

        ReferenceValueDto[] result = response.ReferenceValues.ToArray();

        return result;
    }

    private sealed record ReferenceIdByType(string TemplateId, string ReferenceTypeId, string[] Ids);
}
