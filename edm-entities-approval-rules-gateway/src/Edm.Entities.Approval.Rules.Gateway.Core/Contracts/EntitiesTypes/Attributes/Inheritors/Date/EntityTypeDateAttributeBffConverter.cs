using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Date;

internal static class EntityTypeDateAttributeBffConverter
{
    internal static EntityTypeDateAttributeBff FromDto(EntityTypeAttributeDataBff data)
    {
        var result = new EntityTypeDateAttributeBff
        {
            Data = data
        };

        return result;
    }

    internal static EntityTypeAttributeDto ToDto()
    {
        var asDate = new EntityTypeDateAttributeDto();

        var result = new EntityTypeAttributeDto
        {
            AsDate = asDate
        };

        return result;
    }
}
