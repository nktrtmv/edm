using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Markers;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Briefs;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditBriefInternal<T>
{
    internal AuditBriefInternal(
        Id<AuditUserInternal> createdBy,
        Id<AuditUserInternal> updatedBy,
        UtcDateTime<AuditDateTimeInternal> createdAt,
        UtcDateTime<AuditDateTimeInternal> updatedAt)
    {
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Id<AuditUserInternal> CreatedBy { get; }
    public Id<AuditUserInternal> UpdatedBy { get; }
    public UtcDateTime<AuditDateTimeInternal> CreatedAt { get; }
    public UtcDateTime<AuditDateTimeInternal> UpdatedAt { get; }
}
