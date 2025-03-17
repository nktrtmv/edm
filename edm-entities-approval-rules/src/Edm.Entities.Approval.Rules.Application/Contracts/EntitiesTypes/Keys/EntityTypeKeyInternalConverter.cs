using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

internal static class EntityTypeKeyInternalConverter
{
    internal static EntityTypeKeyInternal FromDomain(EntityTypeKey key)
    {
        DomainId domainId = key.DomainId;
        Id<EntityTypeInternal> entityTypeId = IdConverterFrom<EntityTypeInternal>.From(key.EntityTypeId);
        UtcDateTime<EntityTypeInternal> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityTypeInternal>.From(key.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyInternal(domainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }

    internal static EntityTypeKey ToDomain(EntityTypeKeyInternal key)
    {
        DomainId domainId = key.DomainId;
        Id<EntityType> entityTypeId = IdConverterFrom<EntityType>.From(key.EntityTypeId);
        UtcDateTime<EntityType> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityType>.From(key.EntityTypeUpdatedDate);

        var result = new EntityTypeKey(domainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }
}
