using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;

public sealed class DocumentCommentStatusTransitionParameterValue : DocumentStatusTransitionParameterValue
{
    public DocumentCommentStatusTransitionParameterValue(DocumentStatusTransitionParameter parameter, string comment) : base(parameter)
    {
        Comment = comment;
    }

    public string Comment { get; }

    public override string ToString()
    {
        return $"{{ {BaseToString()}, Comment: {Comment} }}";
    }
}
