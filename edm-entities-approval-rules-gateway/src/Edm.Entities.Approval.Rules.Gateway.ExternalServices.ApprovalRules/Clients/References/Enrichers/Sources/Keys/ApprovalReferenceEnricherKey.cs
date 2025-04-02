using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Enrichers.Sources.Keys;

public sealed record ApprovalReferenceEnricherKey(
    ApprovalReferenceKeyExternal ReferenceKey,
    string[] Ids);
