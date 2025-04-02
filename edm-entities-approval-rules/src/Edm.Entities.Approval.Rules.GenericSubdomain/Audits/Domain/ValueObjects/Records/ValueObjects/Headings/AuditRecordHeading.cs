using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Markers;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditRecordHeading<T>
{
    public AuditRecordHeading(Id<AuditUser> updatedBy, UtcDateTime<AuditDateTime> updatedAt)
    {
        UpdatedBy = updatedBy;
        UpdatedAt = updatedAt;
    }

    public Id<AuditUser> UpdatedBy { get; }
    public UtcDateTime<AuditDateTime> UpdatedAt { get; }
}
