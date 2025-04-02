using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs.Factories;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Audits.Briefs;

internal static class AuditBriefDbConverter
{
    internal static AuditBriefDb FromDomain<T>(AuditBrief<T> brief)
    {
        var createdBy = IdConverterTo.ToString(brief.CreatedBy);

        var updatedBy = IdConverterTo.ToString(brief.UpdatedBy);

        var createdAt = UtcDateTimeConverterTo.ToDateTime(brief.CreatedAt);

        var updatedAt = UtcDateTimeConverterTo.ToDateTime(brief.UpdatedAt);

        var result = new AuditBriefDb
        {
            CreatedBy = createdBy,
            UpdatedBy = updatedBy,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt
        };

        return result;
    }

    internal static AuditBrief<T> ToDomain<T>(ApprovalRuleDb rule)
    {
        Id<AuditUser> createdBy = IdConverterFrom<AuditUser>.FromString(rule.CreatedBy);

        Id<AuditUser> updatedBy = IdConverterFrom<AuditUser>.FromString(rule.UpdatedBy);

        UtcDateTime<AuditDateTime> createdAt = UtcDateTimeConverterFrom<AuditDateTime>.FromUnspecifiedUtcDateTime(rule.CreatedAt);

        UtcDateTime<AuditDateTime> updatedAt = UtcDateTimeConverterFrom<AuditDateTime>.FromUnspecifiedUtcDateTime(rule.UpdatedAt);

        AuditBrief<T> result = AuditBriefFactory<T>.CreateFromDb(createdBy, updatedBy, createdAt, updatedAt);

        return result;
    }
}
