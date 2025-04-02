using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;

public sealed class TupleDocumentAttributeValue : DocumentAttributeValueGeneric<TupleInnerValueDocumentAttributeValue>
{
    public TupleDocumentAttributeValue(DocumentAttribute attribute, TupleInnerValueDocumentAttributeValue[] values) : base(attribute, values)
    {
    }

    public override int CompareTo(DocumentAttributeValue? other)
    {
        throw new ArgumentException($"The Greater/Less operation is not supported by reference attribute value (id:{Attribute.Id}, type:{GetType()}).");
    }
}
