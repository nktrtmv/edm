using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys.Markers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;

internal static class EntityTypeKeyInternalConverter
{
    internal static EntityTypeKey ToDomain(EntityTypeKeyInternal entityTypeKey)
    {
        var domainId = DomainId.Parse(entityTypeKey.DomainId);

        Id<EntityType> entityTypeId = IdConverterFrom<EntityType>.From(entityTypeKey.EntityTypeId);

        UtcDateTime<EntityType> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityType>.From(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKey(domainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }

    internal static EntityTypeKeyInternal FromDomain(EntityTypeKey entityTypeKey)
    {
        Id<EntityTypeInternal> entityTypeId = IdConverterFrom<EntityTypeInternal>.From(entityTypeKey.EntityTypeId);

        UtcDateTime<EntityTypeInternal> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityTypeInternal>.From(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyInternal(entityTypeKey.DomainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }
}
