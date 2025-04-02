using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Markers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;

public static class AuditRecordHeadingInternalConverter<TInternal>
{
    public static AuditRecordHeadingInternal<TInternal> FromDomain<T>(AuditRecordHeading<T> heading)
    {
        Id<AuditUserInternal> updatedById =
            IdConverterFrom<AuditUserInternal>.From(heading.UpdatedById);

        UtcDateTime<AuditDateTimeInternal> updatedDateTime =
            UtcDateTimeConverterFrom<AuditDateTimeInternal>.From(heading.UpdatedDateTime);

        var result = new AuditRecordHeadingInternal<TInternal>(updatedById, updatedDateTime);

        return result;
    }
}
