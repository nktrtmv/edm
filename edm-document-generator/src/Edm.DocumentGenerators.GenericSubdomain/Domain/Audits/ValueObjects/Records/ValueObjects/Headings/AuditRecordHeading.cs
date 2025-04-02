using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditRecordHeading<T>
{
    public AuditRecordHeading(Id<AuditUser> updatedById, UtcDateTime<AuditDateTime> updatedDateTime)
    {
        UpdatedById = updatedById;
        UpdatedDateTime = updatedDateTime;
    }

    public Id<AuditUser> UpdatedById { get; }
    public UtcDateTime<AuditDateTime> UpdatedDateTime { get; }
}
