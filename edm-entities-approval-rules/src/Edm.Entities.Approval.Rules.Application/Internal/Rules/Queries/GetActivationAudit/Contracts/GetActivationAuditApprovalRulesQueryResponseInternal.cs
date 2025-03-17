using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts;

public sealed class GetActivationAuditApprovalRulesQueryResponseInternal
{
    public GetActivationAuditApprovalRulesQueryResponseInternal(ApprovalRuleActivationAuditRecordInternal[] activationAudit)
    {
        ActivationAudit = activationAudit;
    }

    public ApprovalRuleActivationAuditRecordInternal[] ActivationAudit { get; }
}
