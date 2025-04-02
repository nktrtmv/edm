using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Converters.Dates;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Date;

internal static class EntityDateAttributeValueBffConverter
{
    internal static EntityDateAttributeValueBff FromDto(EntityDateAttributeValueDto attributeValue, int id)
    {
        var value = DateOnlyConverter.FromDto(attributeValue.Value.First());

        var result = new EntityDateAttributeValueBff
        {
            Id = id,
            Value = value
        };

        return result;
    }

    internal static EntityAttributeValueDto ToDto(EntityDateAttributeValueBff attributeValue)
    {
        var date = DateOnlyConverter.ToDto(attributeValue.Value);

        Timestamp[] value = { date };

        var asDate = new EntityDateAttributeValueDto
        {
            Value = { value }
        };

        var result = new EntityAttributeValueDto
        {
            Id = attributeValue.Id,
            AsDate = asDate
        };

        return result;
    }
}
