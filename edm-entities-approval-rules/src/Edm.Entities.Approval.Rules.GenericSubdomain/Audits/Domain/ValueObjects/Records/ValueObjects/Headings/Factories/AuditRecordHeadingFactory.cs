using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Markers;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings.Factories;

public static class AuditRecordHeadingFactory<T>
{
    public static AuditRecordHeading<T> CreateNew<TUser>(Id<TUser> currentUserId)
    {
        Id<AuditUser> updatedBy = IdConverterFrom<AuditUser>.From(currentUserId);

        UtcDateTime<AuditDateTime> updatedAt = UtcDateTime<AuditDateTime>.Now;

        var result = new AuditRecordHeading<T>(updatedBy, updatedAt);

        return result;
    }
}
