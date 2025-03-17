namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Attachments;

public sealed class DocumentAttachmentAttributeValueDetailedBff : DocumentAttributeValueDetailedBff
{
    public required Guid[] Values { get; set; }
}
