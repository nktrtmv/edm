namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Contracts.EntityTypesKeys;

public sealed record EntityTypeKeyExternal(
    string DomainId,
    string EntityTypeId,
    DateTime EntityTypeUpdatedDate);
