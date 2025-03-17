using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Markers;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records.ValueObjects.Headings;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditRecordHeadingInternal<T>
{
    internal AuditRecordHeadingInternal(Id<AuditUserInternal> updatedBy, UtcDateTime<AuditDateTimeInternal> updatedAt)
    {
        UpdatedBy = updatedBy;
        UpdatedAt = updatedAt;
    }

    public Id<AuditUserInternal> UpdatedBy { get; }
    public UtcDateTime<AuditDateTimeInternal> UpdatedAt { get; }
}
