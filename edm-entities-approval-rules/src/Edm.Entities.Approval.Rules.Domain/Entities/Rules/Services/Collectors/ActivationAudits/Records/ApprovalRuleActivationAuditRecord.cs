using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.ActivationAudits.Records;

public sealed class ApprovalRuleActivationAuditRecord
{
    internal ApprovalRuleActivationAuditRecord(AuditRecord<ApprovalRule> record, int approvalRuleVersion)
    {
        Record = record;
        ApprovalRuleVersion = approvalRuleVersion;
    }

    public int ApprovalRuleVersion { get; }
    public AuditRecord<ApprovalRule> Record { get; }
}
