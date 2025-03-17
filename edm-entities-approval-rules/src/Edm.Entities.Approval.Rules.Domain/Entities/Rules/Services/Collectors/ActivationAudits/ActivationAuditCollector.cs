using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.ActivationAudits.Records;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.ActivationAudits;

public static class ActivationAuditCollector
{
    public static ApprovalRuleActivationAuditRecord[] Collect(ApprovalRule[] rules)
    {
        var audit = new List<ApprovalRuleActivationAuditRecord>();

        foreach (ApprovalRule rule in rules)
        {
            ApprovalRuleActivationAuditRecord[] records = rule.Audit.Records
                .Where(r => r is ApprovalRuleActivatedAuditRecord or ApprovalRuleDeactivatedAuditRecord)
                .Select(r => new ApprovalRuleActivationAuditRecord(r, rule.Version))
                .ToArray();

            audit.AddRange(records);
        }

        ApprovalRuleActivationAuditRecord[] result = audit.OrderBy(r => r.Record.Heading.UpdatedAt).ToArray();

        return result;
    }
}
