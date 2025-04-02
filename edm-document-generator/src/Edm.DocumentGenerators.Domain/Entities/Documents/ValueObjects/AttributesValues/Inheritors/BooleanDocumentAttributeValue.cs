using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;

public sealed class BooleanDocumentAttributeValue : DocumentAttributeValueGeneric<bool>
{
    public BooleanDocumentAttributeValue(DocumentAttribute attribute, bool[] values) : base(attribute, values)
    {
    }
}
