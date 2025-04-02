using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings.Factories;

public static class AuditRecordHeadingFactory<T>
{
    public static AuditRecordHeading<T> CreateNew<TActor>(Id<TActor> currentUserId)
    {
        Id<AuditUser> actorId = IdConverterFrom<AuditUser>.From(currentUserId);

        UtcDateTime<AuditDateTime> updatedDateTime = UtcDateTime<AuditDateTime>.Now;

        AuditRecordHeading<T> result = CreateFrom(actorId, updatedDateTime);

        return result;
    }

    public static AuditRecordHeading<T> CreateFrom(Id<AuditUser> actorId, UtcDateTime<AuditDateTime> updatedDateTime)
    {
        var result = new AuditRecordHeading<T>(actorId, updatedDateTime);

        return result;
    }
}
