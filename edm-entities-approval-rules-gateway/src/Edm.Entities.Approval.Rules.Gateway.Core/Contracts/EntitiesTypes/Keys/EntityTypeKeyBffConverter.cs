using Edm.Entities.Approval.Rules.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

internal static class EntityTypeKeyBffConverter
{
    internal static EntityTypeKeyDto ToDto(EntityTypeKeyBff key)
    {
        var entityTypeUpdatedDate = Timestamp.FromDateTime(key.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyDto
        {
            DomainId = key.DomainId,
            EntityTypeId = key.EntityTypeId,
            EntityTypeUpdatedDate = entityTypeUpdatedDate
        };

        return result;
    }

    internal static EntityTypeKeyBff FromDto(EntityTypeKeyDto key)
    {
        var entityTypeUpdatedDate = key.EntityTypeUpdatedDate.ToDateTime();

        var result = new EntityTypeKeyBff
        {
            DomainId = key.DomainId,
            EntityTypeId = key.EntityTypeId,
            EntityTypeUpdatedDate = entityTypeUpdatedDate
        };

        return result;
    }
}
