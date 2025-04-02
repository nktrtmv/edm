using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Factories;

public static class EntityAttributeValueFactory
{
    public static EntityAttributeValue CreateBooleanFrom(int id, bool[] value)
    {
        var result = new EntityBooleanAttributeValue(id, value);

        return result;
    }

    public static EntityAttributeValue CreateDateFrom(int id, UtcDateTime<EntityDateAttributeValue>[] value)
    {
        var result = new EntityDateAttributeValue(id, value);

        return result;
    }

    public static EntityAttributeValue CreateNumberFrom(int id, long[] value)
    {
        var result = new EntityNumberAttributeValue(id, value);

        return result;
    }

    public static EntityAttributeValue CreateReferenceFrom(int id, Id<EntityReferenceAttributeValue>[] value)
    {
        var result = new EntityReferenceAttributeValue(id, value);

        return result;
    }

    public static EntityAttributeValue CreateStringFrom(int id, string[] value)
    {
        var result = new EntityStringAttributeValue(id, value);

        return result;
    }
}
