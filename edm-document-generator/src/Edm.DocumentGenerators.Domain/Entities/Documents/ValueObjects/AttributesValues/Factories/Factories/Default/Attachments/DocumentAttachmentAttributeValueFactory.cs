using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Attachments;

internal static class DocumentAttachmentAttributeValueFactory
{
    internal static DocumentAttributeValue CreateDefault(DocumentAttachmentAttribute attribute)
    {
        string[] value = attribute.DefaultValues;

        var result = new AttachmentDocumentAttributeValue(attribute, value);

        return result;
    }
}
