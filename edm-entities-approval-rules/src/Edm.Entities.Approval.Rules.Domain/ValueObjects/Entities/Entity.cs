using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

public sealed class Entity
{
    public Entity(EntityTypeKey typeKey, Dictionary<int, EntityAttributeValue> attributesValues)
    {
        TypeKey = typeKey;
        AttributesValues = attributesValues;
    }

    public EntityTypeKey TypeKey { get; }
    private Dictionary<int, EntityAttributeValue> AttributesValues { get; }

    public EntityAttributeValue GetRequiredAttributeValue(int attributeValueId)
    {
        EntityAttributeValue? attributeValue = AttributesValues.GetValueOrDefault(attributeValueId);

        if (attributeValue is null)
        {
            throw new ArgumentException(
                $"""
                 Required attribute value is not found.
                 AttributeValueId: {attributeValueId}
                 Entity: {this}
                 """);
        }

        return attributeValue;
    }

    public TAttributeValue GetRequiredAttributeValue<TAttributeValue>(int attributeValueId) where TAttributeValue : EntityAttributeValue
    {
        EntityAttributeValue attributeValue = GetRequiredAttributeValue(attributeValueId);

        if (attributeValue is TAttributeValue result)
        {
            return result;
        }

        throw new ArgumentException(
            $"""
             Attribute has incorrect type.
             Required type: {typeof(TAttributeValue)}
             Found type: {attributeValue.GetType()}
             """);
    }

    public override string ToString()
    {
        return $"{{ TypeKey: {TypeKey} }}";
    }
}
