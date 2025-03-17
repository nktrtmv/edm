using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Boolean;

internal static class EntityBooleanAttributeValueBffConverter
{
    internal static EntityBooleanAttributeValueBff FromDto(EntityBooleanAttributeValueDto attributeValue, int id)
    {
        var value = attributeValue.Value.First();

        var result = new EntityBooleanAttributeValueBff
        {
            Id = id,
            Value = value
        };

        return result;
    }

    internal static EntityAttributeValueDto ToDto(EntityBooleanAttributeValueBff attributeValue)
    {
        bool[] value = { attributeValue.Value };

        var asBoolean = new EntityBooleanAttributeValueDto
        {
            Value = { value }
        };

        var result = new EntityAttributeValueDto
        {
            Id = attributeValue.Id,
            AsBoolean = asBoolean
        };

        return result;
    }
}
