namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues.Inheritors.Comments;

public sealed class DocumentCommentStatusTransitionParameterValueBff : DocumentStatusTransitionParameterValueBff
{
    public required string Comment { get; init; }
}
