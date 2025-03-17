namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.CommentsWithAttachments;

public sealed class DocumentAuditCommentWithAttachmentsStatusTransitionParameterValueBff : DocumentAuditStatusTransitionParameterValueBff
{
    public required string Comment { get; init; }
    public required Guid[] Attachments { get; init; }
}
