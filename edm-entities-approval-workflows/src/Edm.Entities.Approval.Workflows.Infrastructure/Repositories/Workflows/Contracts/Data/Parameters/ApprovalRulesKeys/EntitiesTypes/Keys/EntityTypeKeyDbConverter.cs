using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ApprovalRulesKeys.EntitiesTypes.Keys;

internal static class EntityTypeKeyDbConverter
{
    internal static EntityTypeKey ToDomain(EntityTypeKeyDb entityTypeKey)
    {
        var domainId = DomainId.Parse(entityTypeKey.DomainId);

        Id<EntityType> entityTypeId = IdConverterFrom<EntityType>.FromString(entityTypeKey.EntityTypeId);

        UtcDateTime<EntityType> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityType>.FromTimestamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKey(domainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }

    internal static EntityTypeKeyDb FromDomain(EntityTypeKey entityTypeKey)
    {
        var entityTypeId = IdConverterTo.ToString(entityTypeKey.EntityTypeId);

        var entityTypeUpdatedDate = UtcDateTimeConverterTo.ToTimeStamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyDb
        {
            DomainId = entityTypeKey.DomainId,
            EntityTypeId = entityTypeId,
            EntityTypeUpdatedDate = entityTypeUpdatedDate
        };

        return result;
    }
}
