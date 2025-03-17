using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.AttributesValues;

internal static class EntityAttributeValueDbToDomainConverter
{
    internal static EntityAttributeValue ToDomain(EntityAttributeValueDb attributeValue)
    {
        int id = attributeValue.Id;

        EntityAttributeValue result = attributeValue.ValueCase switch
        {
            #region TODO: OBSOLETE - MAKE SURE ALL MIGRATIONS ARE DONE - Int value as long. Value as arrays.

            EntityAttributeValueDb.ValueOneofCase.AsBoolObsolete => CreateBoolFromObsolete(id, attributeValue.AsBoolObsolete),
            EntityAttributeValueDb.ValueOneofCase.AsDateObsolete => CreateDateFromObsolete(id, attributeValue.AsDateObsolete),
            EntityAttributeValueDb.ValueOneofCase.AsIntObsolete => CreateNumberFromObsolete(id, attributeValue.AsIntObsolete),
            EntityAttributeValueDb.ValueOneofCase.AsReferenceObsolete => CreateReferenceFromObsolete(id, attributeValue.AsReferenceObsolete),
            EntityAttributeValueDb.ValueOneofCase.AsStringObsolete => CreateStringFromObsolete(id, attributeValue.AsStringObsolete),

            #endregion

            EntityAttributeValueDb.ValueOneofCase.AsBoolean => ToBoolean(id, attributeValue.AsBoolean),
            EntityAttributeValueDb.ValueOneofCase.AsDate => ToDate(id, attributeValue.AsDate),
            EntityAttributeValueDb.ValueOneofCase.AsNumber => ToNumber(id, attributeValue.AsNumber),
            EntityAttributeValueDb.ValueOneofCase.AsReference => ToReference(id, attributeValue.AsReference),
            EntityAttributeValueDb.ValueOneofCase.AsString => ToString(id, attributeValue.AsString),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    #region TODO: OBSOLETE - MAKE SURE ALL MIGRATIONS ARE DONE - Int value as long. Value as arrays.

    private static EntityAttributeValue CreateBoolFromObsolete(int id, ObsoleteEntityBoolAttributeValueDb attributeValue)
    {
        bool[] value = { attributeValue.Value };

        EntityAttributeValue result = EntityAttributeValueFactory.CreateBooleanFrom(id, value);

        return result;
    }

    private static EntityAttributeValue CreateDateFromObsolete(int id, ObsoleteEntityDateAttributeValueDb attributeValue)
    {
        UtcDateTime<EntityDateAttributeValue>[] value = { UtcDateTimeConverterFrom<EntityDateAttributeValue>.FromTimestamp(attributeValue.Value) };

        EntityAttributeValue result = EntityAttributeValueFactory.CreateDateFrom(id, value);

        return result;
    }

    private static EntityAttributeValue CreateNumberFromObsolete(int id, ObsoleteEntityIntAttributeValueDb attributeValue)
    {
        long[] value = { attributeValue.Value };

        EntityAttributeValue result = EntityAttributeValueFactory.CreateNumberFrom(id, value);

        return result;
    }

    private static EntityAttributeValue CreateReferenceFromObsolete(int id, ObsoleteEntityReferenceAttributeValueDb attributeValue)
    {
        Id<EntityReferenceAttributeValue>[] value = { IdConverterFrom<EntityReferenceAttributeValue>.FromString(attributeValue.Value) };

        EntityAttributeValue result = EntityAttributeValueFactory.CreateReferenceFrom(id, value);

        return result;
    }

    private static EntityAttributeValue CreateStringFromObsolete(int id, ObsoleteEntityStringAttributeValueDb attributeValue)
    {
        string[] value = { attributeValue.Value };

        EntityAttributeValue result = EntityAttributeValueFactory.CreateStringFrom(id, value);

        return result;
    }

    #endregion

    private static EntityAttributeValue ToBoolean(int id, EntityBooleanAttributeValueDb attributeValue)
    {
        bool[] value = attributeValue.Value.ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateBooleanFrom(id, value);

        return result;
    }

    private static EntityAttributeValue ToDate(int id, EntityDateAttributeValueDb attributeValue)
    {
        UtcDateTime<EntityDateAttributeValue>[] value =
            attributeValue.Value.Select(UtcDateTimeConverterFrom<EntityDateAttributeValue>.FromTimestamp).ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateDateFrom(id, value);

        return result;
    }

    private static EntityAttributeValue ToNumber(int id, EntityNumberAttributeValueDb attributeValue)
    {
        long[] value = attributeValue.Value.ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateNumberFrom(id, value);

        return result;
    }

    private static EntityAttributeValue ToReference(int id, EntityReferenceAttributeValueDb attributeValue)
    {
        Id<EntityReferenceAttributeValue>[] value =
            attributeValue.Value.Select(IdConverterFrom<EntityReferenceAttributeValue>.FromString).ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateReferenceFrom(id, value);

        return result;
    }

    private static EntityAttributeValue ToString(int id, EntityStringAttributeValueDb attributeValue)
    {
        string[] value = attributeValue.Value.ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateStringFrom(id, value);

        return result;
    }
}
