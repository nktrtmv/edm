using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Markers;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditBriefInternal<T>
{
    public AuditBriefInternal(
        Id<AuditUserInternal> createdById,
        Id<AuditUserInternal> updatedById,
        UtcDateTime<AuditDateTimeInternal> createdDateTime,
        UtcDateTime<AuditDateTimeInternal> updatedDateTime)
    {
        CreatedById = createdById;
        UpdatedById = updatedById;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public Id<AuditUserInternal> CreatedById { get; }
    public Id<AuditUserInternal> UpdatedById { get; }
    public UtcDateTime<AuditDateTimeInternal> CreatedDateTime { get; }
    public UtcDateTime<AuditDateTimeInternal> UpdatedDateTime { get; }
}
