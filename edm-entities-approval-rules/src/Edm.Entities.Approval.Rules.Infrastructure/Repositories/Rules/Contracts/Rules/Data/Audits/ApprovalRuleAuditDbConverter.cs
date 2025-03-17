using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Audits.Briefs;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits.Records;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits;

internal static class ApprovalRuleAuditDbConverter
{
    internal static ApprovalRuleAuditDb FromDomain(Audit<ApprovalRule> audit)
    {
        AuditBriefDb brief = AuditBriefDbConverter.FromDomain(audit.Brief);

        ApprovalRuleAuditRecordDb[] records = audit.Records.Select(ApprovalRuleAuditRecordDbFromDomainConverter.FromDomain).ToArray();

        var result = new ApprovalRuleAuditDb(brief, records);

        return result;
    }

    internal static Audit<ApprovalRule> ToDomain(ApprovalRuleDb rule, IEnumerable<ApprovalRuleAuditRecordDb> recordsDb)
    {
        AuditBrief<ApprovalRule> brief = AuditBriefDbConverter.ToDomain<ApprovalRule>(rule);

        AuditRecord<ApprovalRule>[] records = recordsDb.Select(ApprovalRuleAuditRecordDbToDomainConverter.ToDomain).ToArray();

        Audit<ApprovalRule> result = AuditFactory<ApprovalRule>.CreateFromDb(brief, records);

        return result;
    }
}
