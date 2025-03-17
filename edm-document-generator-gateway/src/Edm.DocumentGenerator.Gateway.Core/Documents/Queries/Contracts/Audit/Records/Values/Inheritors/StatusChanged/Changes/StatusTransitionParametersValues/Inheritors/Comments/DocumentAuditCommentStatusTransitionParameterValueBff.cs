namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.Comments;

public sealed class DocumentAuditCommentStatusTransitionParameterValueBff : DocumentAuditStatusTransitionParameterValueBff
{
    public required string Comment { get; init; }
}
