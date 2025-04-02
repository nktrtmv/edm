using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Briefs;

public static class AuditBriefInternalConverterFrom<T>
{
    public static AuditBriefInternal<T> FromDomain<TSource>(AuditBrief<TSource> brief)
    {
        Id<AuditUserInternal> createdBy = IdConverterFrom<AuditUserInternal>.From(brief.CreatedBy);
        Id<AuditUserInternal> updatedBy = IdConverterFrom<AuditUserInternal>.From(brief.UpdatedBy);

        UtcDateTime<AuditDateTimeInternal> createdAt = UtcDateTimeConverterFrom<AuditDateTimeInternal>.From(brief.CreatedAt);
        UtcDateTime<AuditDateTimeInternal> updatedAt = UtcDateTimeConverterFrom<AuditDateTimeInternal>.From(brief.UpdatedAt);

        var result = new AuditBriefInternal<T>(createdBy, updatedBy, createdAt, updatedAt);

        return result;
    }
}
