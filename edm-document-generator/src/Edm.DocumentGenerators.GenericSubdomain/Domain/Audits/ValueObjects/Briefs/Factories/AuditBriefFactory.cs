using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs.Factories;

public static class AuditBriefFactory<T>
{
    public static AuditBrief<T> CreateNew(Id<AuditUser> currentUserId)
    {
        UtcDateTime<AuditDateTime> currentDateTime = UtcDateTime<AuditDateTime>.Now;

        AuditBrief<T> result = CreateFromDb(
            currentUserId,
            currentUserId,
            currentDateTime,
            currentDateTime);

        return result;
    }

    public static AuditBrief<T> CreateFrom(
        AuditBrief<T> brief,
        Id<AuditUser> updatedById,
        UtcDateTime<AuditDateTime> updatedDateTime)
    {
        AuditBrief<T> result = CreateFromDb(
            brief.CreatedById,
            updatedById,
            brief.CreatedDateTime,
            updatedDateTime);

        return result;
    }

    public static AuditBrief<T> CreateFromDb(
        Id<AuditUser> createdById,
        Id<AuditUser> updatedById,
        UtcDateTime<AuditDateTime> createdDateTime,
        UtcDateTime<AuditDateTime> updatedDateTime)
    {
        var result = new AuditBrief<T>(
            createdById,
            updatedById,
            createdDateTime,
            updatedDateTime);

        return result;
    }
}
