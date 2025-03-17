namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Attachments;

public sealed class DocumentAttachmentAttributeValueBareBff : DocumentAttributeValueBareBff
{
    public required string[] Values { get; init; }
}
