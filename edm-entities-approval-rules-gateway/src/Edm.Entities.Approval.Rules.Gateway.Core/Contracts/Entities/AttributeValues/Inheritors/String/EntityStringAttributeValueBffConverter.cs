using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.String;

internal static class EntityStringAttributeValueBffConverter
{
    internal static EntityStringAttributeValueBff FromDto(EntityStringAttributeValueDto attributeValue, int id)
    {
        var value = attributeValue.Value.First();

        var result = new EntityStringAttributeValueBff
        {
            Id = id,
            Value = value
        };

        return result;
    }

    internal static EntityAttributeValueDto ToDto(EntityStringAttributeValueBff attributeValue)
    {
        string[] value = { attributeValue.Value };

        var asString = new EntityStringAttributeValueDto
        {
            Value = { value }
        };

        var result = new EntityAttributeValueDto
        {
            Id = attributeValue.Id,
            AsString = asString
        };

        return result;
    }
}
