using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Markers;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditRecordHeadingInternal<T>
{
    public AuditRecordHeadingInternal(
        Id<AuditUserInternal> updatedById,
        UtcDateTime<AuditDateTimeInternal> updatedDateTime)
    {
        UpdatedById = updatedById;
        UpdatedDateTime = updatedDateTime;
    }

    public Id<AuditUserInternal> UpdatedById { get; }
    public UtcDateTime<AuditDateTimeInternal> UpdatedDateTime { get; }
}
