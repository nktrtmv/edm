using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts;

public sealed class GetActivationAuditApprovalRulesQueryResponseBff
{
    public required GetActivationAuditApprovalRulesQueryResponseAuditRecordBff[] ActivationAudit { get; init; }
}
