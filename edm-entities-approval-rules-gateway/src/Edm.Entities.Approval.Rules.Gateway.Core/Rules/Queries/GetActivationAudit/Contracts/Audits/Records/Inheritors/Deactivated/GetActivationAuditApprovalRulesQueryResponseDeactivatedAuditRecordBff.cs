namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Inheritors.Deactivated;

public sealed class GetActivationAuditApprovalRulesQueryResponseDeactivatedAuditRecordBff
    : GetActivationAuditApprovalRulesQueryResponseAuditRecordBff
{
    public required string Comment { get; init; }
}
