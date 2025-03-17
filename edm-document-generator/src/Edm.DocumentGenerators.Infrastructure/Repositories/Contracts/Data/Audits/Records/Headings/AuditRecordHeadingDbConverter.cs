using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings.Factories;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Audits.Records.Headings;

internal static class AuditRecordHeadingDbConverter
{
    internal static AuditRecordHeadingDb FromDomain<T>(AuditRecordHeading<T> heading)
    {
        var updatedById = IdConverterTo.ToString(heading.UpdatedById);

        Timestamp updatedDateTime = UtcDateTimeConverterTo.ToTimeStamp(heading.UpdatedDateTime);

        var result = new AuditRecordHeadingDb
        {
            UpdatedById = updatedById,
            UpdatedDateTime = updatedDateTime
        };

        return result;
    }

    internal static AuditRecordHeading<T> ToDomain<T>(AuditRecordHeadingDb heading)
    {
        Id<AuditUser> updatedById = IdConverterFrom<AuditUser>.FromString(heading.UpdatedById);

        UtcDateTime<AuditDateTime> updatedDateTime = UtcDateTimeConverterFrom<AuditDateTime>.FromTimestamp(heading.UpdatedDateTime);

        AuditRecordHeading<T> result = AuditRecordHeadingFactory<T>.CreateFrom(updatedById, updatedDateTime);

        return result;
    }
}
