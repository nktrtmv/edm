using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;

public sealed class ApprovalRuleActivationAuditRecordInternal
{
    public ApprovalRuleActivationAuditRecordInternal(int approvalRuleVersion, AuditRecordInternal<ApprovalRuleInternal> record)
    {
        ApprovalRuleVersion = approvalRuleVersion;
        Record = record;
    }

    public int ApprovalRuleVersion { get; }
    public AuditRecordInternal<ApprovalRuleInternal> Record { get; }
}
