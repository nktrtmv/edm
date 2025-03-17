namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues.Inheritors.CommentsWithAttachments;

public sealed class DocumentCommentWithAttachmentsStatusTransitionParameterValueBff : DocumentStatusTransitionParameterValueBff
{
    public required string Comment { get; init; }
    public required string[] AttachmentsIds { get; init; }
}
