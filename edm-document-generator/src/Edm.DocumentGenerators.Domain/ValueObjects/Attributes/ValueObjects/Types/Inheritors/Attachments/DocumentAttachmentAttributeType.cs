namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Attachments;

public sealed class DocumentAttachmentAttributeType : DocumentAttributeType
{
    private DocumentAttachmentAttributeType()
    {
    }

    public static DocumentAttachmentAttributeType Instance { get; } = new DocumentAttachmentAttributeType();
}
