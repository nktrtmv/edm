using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;

public sealed class ReferenceDocumentAttributeValue : DocumentAttributeValueGeneric<string>
{
    public ReferenceDocumentAttributeValue(DocumentAttribute attribute, string[] values) : base(attribute, values)
    {
    }

    public override int CompareTo(DocumentAttributeValue? other)
    {
        throw new ArgumentException($"The Greater/Less operation is not supported by reference attribute value (id:{Attribute.Id}, type:{GetType()}).");
    }
}
