using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;

internal static class EntityTypeAttributeDataBffConverter
{
    internal static EntityTypeAttributeDataBff FromDto(EntityTypeAttributeDataDto data)
    {
        var result = new EntityTypeAttributeDataBff
        {
            Id = data.Id,
            DisplayName = data.DisplayName
        };

        return result;
    }

    internal static EntityTypeAttributeDataDto ToDto(EntityTypeAttributeDataBff data)
    {
        var result = new EntityTypeAttributeDataDto
        {
            Id = data.Id,
            DisplayName = data.DisplayName
        };

        return result;
    }
}
