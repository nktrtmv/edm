using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Markers;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs.Factories;

public static class AuditBriefFactory<T>
{
    public static AuditBrief<T> CreateNew(Id<AuditUser> auditUserId)
    {
        UtcDateTime<AuditDateTime> currentDateTime = UtcDateTime<AuditDateTime>.Now;

        AuditBrief<T> result = CreateFromDb(
            auditUserId,
            auditUserId,
            currentDateTime,
            currentDateTime);

        return result;
    }

    public static AuditBrief<T> CreateFrom(
        AuditBrief<T> brief,
        Id<AuditUser> updatedBy,
        UtcDateTime<AuditDateTime> updatedAt)
    {
        AuditBrief<T> result = CreateFromDb(
            brief.CreatedBy,
            updatedBy,
            brief.CreatedAt,
            updatedAt);

        return result;
    }

    public static AuditBrief<T> CreateFromDb(
        Id<AuditUser> createdBy,
        Id<AuditUser> updatedBy,
        UtcDateTime<AuditDateTime> createdAt,
        UtcDateTime<AuditDateTime> updatedAt)
    {
        var result = new AuditBrief<T>(
            createdBy,
            updatedBy,
            createdAt,
            updatedAt);

        return result;
    }
}
