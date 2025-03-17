using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.Comments;

internal static class DocumentCommentStatusTransitionParameterValueInternalConverter
{
    internal static DocumentCommentStatusTransitionParameterValueInternal FromDomain(DocumentCommentStatusTransitionParameterValue parameterValue)
    {
        var result = new DocumentCommentStatusTransitionParameterValueInternal(parameterValue.Comment);

        return result;
    }

    internal static DocumentCommentStatusTransitionParameterValue ToDomain(
        DocumentStatusTransitionParameter parameter,
        DocumentCommentStatusTransitionParameterValueInternal parameterValue)
    {
        var result = new DocumentCommentStatusTransitionParameterValue(parameter, parameterValue.Comment);

        return result;
    }
}
