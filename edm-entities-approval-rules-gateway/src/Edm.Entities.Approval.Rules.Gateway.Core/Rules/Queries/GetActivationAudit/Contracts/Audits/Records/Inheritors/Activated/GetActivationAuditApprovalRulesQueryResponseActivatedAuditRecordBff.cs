namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Inheritors.Activated;

public sealed class GetActivationAuditApprovalRulesQueryResponseActivatedAuditRecordBff
    : GetActivationAuditApprovalRulesQueryResponseAuditRecordBff
{
    public required string Comment { get; init; }
}
