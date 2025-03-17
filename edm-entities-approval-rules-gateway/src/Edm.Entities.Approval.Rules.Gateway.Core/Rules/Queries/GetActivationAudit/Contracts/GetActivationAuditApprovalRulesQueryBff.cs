using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts;

public sealed class GetActivationAuditApprovalRulesQueryBff
{
    public required EntityTypeKeyBff EntityTypeKey { get; init; }
}
