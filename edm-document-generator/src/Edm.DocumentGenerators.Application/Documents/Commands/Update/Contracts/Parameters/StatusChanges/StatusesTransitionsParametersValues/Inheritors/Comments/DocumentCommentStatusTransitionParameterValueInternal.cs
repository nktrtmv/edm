namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.Comments;

public sealed class DocumentCommentStatusTransitionParameterValueInternal : DocumentStatusTransitionParameterValueInternal
{
    public DocumentCommentStatusTransitionParameterValueInternal(string comment)
    {
        Comment = comment;
    }

    public string Comment { get; }
}
