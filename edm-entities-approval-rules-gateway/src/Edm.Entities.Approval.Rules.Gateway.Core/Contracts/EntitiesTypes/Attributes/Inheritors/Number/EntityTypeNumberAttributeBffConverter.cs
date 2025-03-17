using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Number;

internal static class EntityTypeNumberAttributeBffConverter
{
    internal static EntityTypeNumberAttributeBff FromDto(EntityTypeAttributeDataBff data, EntityTypeNumberAttributeDto attribute)
    {
        var result = new EntityTypeNumberAttributeBff
        {
            Data = data,
            Precision = attribute.Precision
        };

        return result;
    }

    internal static EntityTypeAttributeDto ToDto(EntityTypeNumberAttributeBff attribute)
    {
        var asNumber = new EntityTypeNumberAttributeDto
        {
            Precision = attribute.Precision
        };

        var result = new EntityTypeAttributeDto
        {
            AsNumber = asNumber
        };

        return result;
    }
}
