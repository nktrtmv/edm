using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Markers;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs;

// ReSharper disable once UnusedTypeParameter
public sealed class AuditBrief<T>
{
    public AuditBrief(
        Id<AuditUser> createdBy,
        Id<AuditUser> updatedBy,
        UtcDateTime<AuditDateTime> createdAt,
        UtcDateTime<AuditDateTime> updatedAt)
    {
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Id<AuditUser> CreatedBy { get; }
    public Id<AuditUser> UpdatedBy { get; }
    public UtcDateTime<AuditDateTime> CreatedAt { get; }
    public UtcDateTime<AuditDateTime> UpdatedAt { get; }
}
