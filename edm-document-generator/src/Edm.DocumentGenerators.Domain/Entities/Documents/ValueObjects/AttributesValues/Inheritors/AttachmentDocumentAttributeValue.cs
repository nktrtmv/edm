using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;

public sealed class AttachmentDocumentAttributeValue : DocumentAttributeValueGeneric<string>
{
    public AttachmentDocumentAttributeValue(DocumentAttribute attribute, string[] values) : base(attribute, values)
    {
    }
}
