namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Attachments;

public sealed class DocumentAttachmentAuditAttributeValueBff : DocumentAuditAttributeValueBff
{
    public required Guid[] Value { get; init; }
}
