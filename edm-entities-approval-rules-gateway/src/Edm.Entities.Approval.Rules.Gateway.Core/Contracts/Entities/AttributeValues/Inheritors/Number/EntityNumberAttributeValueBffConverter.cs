using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Number;

internal static class EntityNumberAttributeValueBffConverter
{
    internal static EntityNumberAttributeValueBff FromDto(EntityNumberAttributeValueDto attributeValue, int id)
    {
        var value = attributeValue.Value.First();

        var result = new EntityNumberAttributeValueBff
        {
            Id = id,
            Value = value
        };

        return result;
    }

    internal static EntityAttributeValueDto ToDto(EntityNumberAttributeValueBff attributeValue)
    {
        long[] value = { attributeValue.Value };

        var asNumber = new EntityNumberAttributeValueDto
        {
            Value = { value }
        };

        var result = new EntityAttributeValueDto
        {
            Id = attributeValue.Id,
            AsNumber = asNumber
        };

        return result;
    }
}
