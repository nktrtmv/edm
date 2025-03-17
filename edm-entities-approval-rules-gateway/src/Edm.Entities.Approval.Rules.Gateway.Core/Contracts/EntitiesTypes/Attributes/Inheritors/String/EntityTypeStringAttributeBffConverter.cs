using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.String;

internal static class EntityTypeStringAttributeBffConverter
{
    internal static EntityTypeStringAttributeBff FromDto(EntityTypeAttributeDataBff data)
    {
        var result = new EntityTypeStringAttributeBff
        {
            Data = data
        };

        return result;
    }

    internal static EntityTypeAttributeDto ToDto()
    {
        var asString = new EntityTypeStringAttributeDto();

        var result = new EntityTypeAttributeDto
        {
            AsString = asString
        };

        return result;
    }
}
