using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Extensions.Types;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;

public sealed class NumberDocumentAttributeValue : DocumentAttributeValueGeneric<Number<NumberDocumentAttributeValue>>
{
    public NumberDocumentAttributeValue(DocumentAttribute attribute, Number<NumberDocumentAttributeValue>[] values) : base(attribute, values)
    {
    }

    public override int CompareTo(DocumentAttributeValue? other)
    {
        NumberDocumentAttributeValue otherAttributeValue = TypeCasterTo<NumberDocumentAttributeValue>.CastRequired(other);

        DocumentNumberAttribute otherAttribute = TypeCasterTo<DocumentNumberAttribute>.CastRequired(otherAttributeValue.Attribute);

        DocumentNumberAttribute currentAttribute = TypeCasterTo<DocumentNumberAttribute>.CastRequired(Attribute);

        if (currentAttribute.Precision != otherAttribute.Precision)
        {
            throw new ApplicationException(
                $$"""
                  The Greater/Less operation is not supported.
                  Reason: Number attribute values have different precision.
                  CurrentAttributeValue: { Id: {{currentAttribute.Id}}, Precision: {{currentAttribute.Precision}}, Type: {{currentAttribute.GetType()}} }
                  OtherAttributeValue: { Id: {{otherAttribute.Id}}, Precision: {{otherAttribute.Precision}}, Type: {{otherAttribute.GetType()}} }
                  """);
        }

        int result = base.CompareTo(other);

        return result;
    }
}
