using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;

public sealed class ConditionTargetDocumentAttribute : IConditionTarget
{
    public ConditionTargetDocumentAttribute(Id<DocumentAttribute> documentAttributeId)
    {
        DocumentAttributeId = documentAttributeId;
    }

    public Id<DocumentAttribute> DocumentAttributeId { get; init; }

    public T GetValue<T>(DocumentAttributeValue[] attributesValues)
    {
        DocumentAttributeValue attributeValue = attributesValues
            .Single(p => p.Attribute.Id == DocumentAttributeId);

        if (attributeValue is not DocumentAttributeValueGeneric<T> genericAttributeValue)
        {
            throw new UnsupportedTypeArgumentException<DocumentAttributeValueGeneric<T>>(attributeValue);
        }

        if (genericAttributeValue.Attribute.IsArray)
        {
            throw new NotSupportedException("Array attributes are not supported for condition's target.");
        }

        return genericAttributeValue.Values.Single();
    }

    public bool TypeIs<T>(DocumentAttributeValue[] attributesValues)
    {
        DocumentAttributeValue attributeValue = attributesValues
            .Single(p => p.Attribute.Id == DocumentAttributeId);

        return attributeValue is DocumentAttributeValueGeneric<T>;
    }
}
