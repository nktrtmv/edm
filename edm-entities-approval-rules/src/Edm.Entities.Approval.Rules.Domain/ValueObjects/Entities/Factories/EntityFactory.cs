using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.Factories;

public static class EntityFactory
{
    public static Entity CreateFrom(EntityTypeKey typeKey, EntityAttributeValue[] attributesValues)
    {
        Dictionary<int, EntityAttributeValue> valuesById = attributesValues.ToDictionary(x => x.Id);

        var result = new Entity(typeKey, valuesById);

        return result;
    }
}
