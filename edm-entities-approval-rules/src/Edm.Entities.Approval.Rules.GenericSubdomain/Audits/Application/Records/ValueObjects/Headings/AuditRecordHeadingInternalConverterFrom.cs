using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records.ValueObjects.Headings;

public static class AuditRecordHeadingInternalConverter<T>
{
    public static AuditRecordHeadingInternal<T> FromDomain<TSource>(AuditRecordHeading<TSource> heading)
    {
        Id<AuditUserInternal> updatedBy = IdConverterFrom<AuditUserInternal>.From(heading.UpdatedBy);
        UtcDateTime<AuditDateTimeInternal> updatedAt = UtcDateTimeConverterFrom<AuditDateTimeInternal>.From(heading.UpdatedAt);

        var result = new AuditRecordHeadingInternal<T>(updatedBy, updatedAt);

        return result;
    }
}
