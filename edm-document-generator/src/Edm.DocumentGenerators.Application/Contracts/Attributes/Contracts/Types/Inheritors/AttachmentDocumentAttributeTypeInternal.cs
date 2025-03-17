namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types.Inheritors;

public sealed record AttachmentDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    private AttachmentDocumentAttributeTypeInternal()
    {
    }

    public static AttachmentDocumentAttributeTypeInternal Instance { get; } = new AttachmentDocumentAttributeTypeInternal();
}
