using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;

public sealed class StringDocumentAttributeValue : DocumentAttributeValueGeneric<string>
{
    public StringDocumentAttributeValue(DocumentAttribute attribute, string[] values) : base(attribute, values)
    {
    }
}
