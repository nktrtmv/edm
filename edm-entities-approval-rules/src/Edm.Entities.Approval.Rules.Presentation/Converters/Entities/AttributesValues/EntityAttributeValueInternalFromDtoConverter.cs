using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Presentation.Converters.Entities.AttributesValues;

internal static class EntityAttributeValueInternalFromDtoConverter
{
    internal static EntityAttributeValueInternal FromDto(EntityAttributeValueDto attributeValue)
    {
        int id = attributeValue.Id;

        EntityAttributeValueInternal result = attributeValue.ValueCase switch
        {
            EntityAttributeValueDto.ValueOneofCase.AsBoolean => ToBoolean(id, attributeValue.AsBoolean),
            EntityAttributeValueDto.ValueOneofCase.AsDate => ToDate(id, attributeValue.AsDate),
            EntityAttributeValueDto.ValueOneofCase.AsNumber => ToNumber(id, attributeValue.AsNumber),
            EntityAttributeValueDto.ValueOneofCase.AsReference => ToReference(id, attributeValue.AsReference),
            EntityAttributeValueDto.ValueOneofCase.AsString => ToString(id, attributeValue.AsString),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static EntityBooleanAttributeValueInternal ToBoolean(int id, EntityBooleanAttributeValueDto attributeValue)
    {
        bool[] value = attributeValue.Value.ToArray();

        var result = new EntityBooleanAttributeValueInternal(id, value);

        return result;
    }

    private static EntityDateAttributeValueInternal ToDate(int id, EntityDateAttributeValueDto attributeValue)
    {
        UtcDateTime<EntityDateAttributeValueInternal>[] value =
            attributeValue.Value.Select(UtcDateTimeConverterFrom<EntityDateAttributeValueInternal>.FromTimestamp).ToArray();

        var result = new EntityDateAttributeValueInternal(id, value);

        return result;
    }

    private static EntityNumberAttributeValueInternal ToNumber(int id, EntityNumberAttributeValueDto attributeValue)
    {
        long[] value = attributeValue.Value.ToArray();

        var result = new EntityNumberAttributeValueInternal(id, value);

        return result;
    }

    private static EntityReferenceAttributeValueInternal ToReference(int id, EntityReferenceAttributeValueDto attributeValue)
    {
        Id<EntityReferenceAttributeValueInternal>[] value =
            attributeValue.Value.Select(IdConverterFrom<EntityReferenceAttributeValueInternal>.FromString).ToArray();

        var result = new EntityReferenceAttributeValueInternal(id, value);

        return result;
    }

    private static EntityStringAttributeValueInternal ToString(int id, EntityStringAttributeValueDto attributeValue)
    {
        string[] value = attributeValue.Value.ToArray();

        var result = new EntityStringAttributeValueInternal(id, value);

        return result;
    }
}
