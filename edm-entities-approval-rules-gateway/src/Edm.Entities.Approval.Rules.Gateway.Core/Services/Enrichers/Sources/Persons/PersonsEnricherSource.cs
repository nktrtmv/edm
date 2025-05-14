using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Enrichers.Sources.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Contracts.EntityTypesKeys;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources.Generics;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources.Generics.SingleKey;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Sources.Persons;

internal sealed class PersonsEnricherSource(
    IApprovalReferencesClient client,
    ILogger<EnricherSourceGeneric<IApprovalReferencesClient, string, ApprovalReferenceValueExternal>> logger)
    : SingleKeyEnricherSourceGeneric<IApprovalReferencesClient, string, ApprovalReferenceValueExternal>(client, logger)
{
    protected override async Task<Dictionary<string, ApprovalReferenceValueExternal>> GetValues(string[] keys, CancellationToken cancellationToken)
    {
        var key = new ApprovalReferenceEnricherKey(
            new ApprovalReferenceKeyExternal(
                new EntityTypeKeyExternal(
                    "8a3d776c-906a-4de2-9c20-1df638f1545b",
                    string.Empty,
                    default),
                "{\"TypeId\":300}"),
            keys);

        var request = new SearchValuesApprovalReferencesQueryExternal(key.ReferenceKey, key.Ids, string.Empty, 0, int.MaxValue);

        var response = await Client.SearchValues(request, cancellationToken);

        var result = response.Values.ToDictionary(c => c.Id);

        return result;
    }
}
