using Edm.Entities.Approval.Rules.Domain.Entities.Domains;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

public sealed class EntityTypeKey
{
    public EntityTypeKey(
        DomainId domainId,
        Id<EntityType> entityTypeId,
        UtcDateTime<EntityType> entityTypeUpdatedDate)
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
        var entityTypeUpdatedDate = UtcDateTimeConverterTo.ToString(EntityTypeUpdatedDate);

        return $"{{ DomainId: {DomainId.Value}, EntityTypeId: {EntityTypeId}, EntityTypeUpdatedDate: {entityTypeUpdatedDate} }}";
    }
}
