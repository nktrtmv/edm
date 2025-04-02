using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Audits.Briefs;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits;

internal sealed class ApprovalRuleAuditDb
{
    internal ApprovalRuleAuditDb(AuditBriefDb brief, ApprovalRuleAuditRecordDb[] records)
    {
        Brief = brief;
        Records = records;
    }

    internal AuditBriefDb Brief { get; }
    internal ApprovalRuleAuditRecordDb[] Records { get; }
}
