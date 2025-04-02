using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Converters.ApprovalRulesKeys.EntitiesTypes.Keys;

internal static class EntityTypeKeyDtoConverter
{
    internal static EntityTypeKeyInternal ToInternal(EntityTypeKeyDto entityTypeKey)
    {
        Id<EntityTypeInternal> entityTypeId = IdConverterFrom<EntityTypeInternal>.FromString(entityTypeKey.EntityTypeId);

        UtcDateTime<EntityTypeInternal> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityTypeInternal>.FromTimestamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyInternal(entityTypeKey.DomainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }

    internal static EntityTypeKeyDto FromInternal(EntityTypeKeyInternal entityTypeKey)
    {
        var entityTypeId = IdConverterTo.ToString(entityTypeKey.EntityTypeId);

        var entityTypeUpdatedDate = UtcDateTimeConverterTo.ToTimeStamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyDto
        {
            DomainId = entityTypeKey.DomainId,
            EntityTypeId = entityTypeId,
            EntityTypeUpdatedDate = entityTypeUpdatedDate
        };

        return result;
    }
}
