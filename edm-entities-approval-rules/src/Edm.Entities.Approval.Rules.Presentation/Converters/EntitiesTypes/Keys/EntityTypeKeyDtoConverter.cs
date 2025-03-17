using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

internal static class EntityTypeKeyDtoConverter
{
    internal static EntityTypeKeyDto FromInternal(EntityTypeKeyInternal entityTypeKey)
    {
        string domainId = entityTypeKey.DomainId.Value;

        var entityTypeId = IdConverterTo.ToString(entityTypeKey.EntityTypeId);

        Timestamp entityTypeUpdatedDate = UtcDateTimeConverterTo.ToTimeStamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyDto
        {
            DomainId = domainId,
            EntityTypeId = entityTypeId,
            EntityTypeUpdatedDate = entityTypeUpdatedDate
        };

        return result;
    }

    internal static EntityTypeKeyInternal ToInternal(EntityTypeKeyDto entityTypeKey)
    {
        DomainId domainId = DomainId.Parse(entityTypeKey.DomainId);

        Id<EntityTypeInternal> entityTypeId =
            IdConverterFrom<EntityTypeInternal>.FromString(entityTypeKey.EntityTypeId);

        UtcDateTime<EntityTypeInternal> entityTypeUpdatedDate =
            UtcDateTimeConverterFrom<EntityTypeInternal>.FromTimestamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyInternal(domainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }
}
