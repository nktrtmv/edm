using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys;

public sealed class EntityTypeKey
{
    public EntityTypeKey(DomainId domainId, Id<EntityType> entityTypeId, UtcDateTime<EntityType> entityTypeUpdatedDate)
    {
        DomainId = domainId;
        EntityTypeId = entityTypeId;
        EntityTypeUpdatedDate = entityTypeUpdatedDate;
    }

    public DomainId DomainId { get; }
    public Id<EntityType> EntityTypeId { get; }
    public UtcDateTime<EntityType> EntityTypeUpdatedDate { get; }

    public override string ToString()
    {
        return $"{{ DomainId: {DomainId}, EntityTypeId: {EntityTypeId}, EntityTypeUpdatedDate: {EntityTypeUpdatedDate} }}";
    }
}
