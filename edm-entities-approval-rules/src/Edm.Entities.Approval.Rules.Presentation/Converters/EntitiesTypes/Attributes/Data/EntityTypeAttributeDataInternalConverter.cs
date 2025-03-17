using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes.Data;

internal static class EntityTypeAttributeDataInternalConverter
{
    internal static EntityTypeAttributeDataInternal FromDto(EntityTypeAttributeDataDto data)
    {
        var result = new EntityTypeAttributeDataInternal(data.Id, data.DisplayName);

        return result;
    }

    internal static EntityTypeAttributeDataDto ToDto(EntityTypeAttributeDataInternal data)
    {
        var result = new EntityTypeAttributeDataDto
        {
            Id = data.Id,
            DisplayName = data.DisplayName
        };

        return result;
    }
}
