using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Boolean;

internal static class EntityTypeBooleanAttributeBffConverter
{
    internal static EntityTypeBooleanAttributeBff FromDto(EntityTypeAttributeDataBff data)
    {
        var result = new EntityTypeBooleanAttributeBff
        {
            Data = data
        };

        return result;
    }

    internal static EntityTypeAttributeDto ToDto()
    {
        var asBoolean = new EntityTypeBooleanAttributeDto();

        var result = new EntityTypeAttributeDto
        {
            AsBoolean = asBoolean
        };

        return result;
    }
}
