using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditBrief<T>
{
    internal AuditBrief(
        Id<AuditUser> createdById,
        Id<AuditUser> updatedById,
        UtcDateTime<AuditDateTime> createdDateTime,
        UtcDateTime<AuditDateTime> updatedDateTime)
    {
        CreatedById = createdById;
        UpdatedById = updatedById;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public Id<AuditUser> CreatedById { get; }
    public Id<AuditUser> UpdatedById { get; private set; }
    public UtcDateTime<AuditDateTime> CreatedDateTime { get; }
    public UtcDateTime<AuditDateTime> UpdatedDateTime { get; private set; }
}
