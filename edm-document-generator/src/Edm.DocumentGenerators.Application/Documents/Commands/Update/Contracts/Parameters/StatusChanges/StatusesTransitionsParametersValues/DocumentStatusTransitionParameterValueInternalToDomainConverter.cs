using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;

internal static class DocumentStatusTransitionParameterValueInternalToDomainConverter
{
    internal static DocumentStatusTransitionParameterValue[] ToDomain(
        DocumentStatusTransitionParameterValueInternal[] parametersValues,
        DocumentStatusTransition statusTransition)
    {
        DocumentStatusTransitionParameterValue[] result =
            parametersValues.Select(v => ToDomain(v, statusTransition.Parameters)).ToArray();

        return result;
    }

    private static DocumentStatusTransitionParameterValue ToDomain(
        DocumentStatusTransitionParameterValueInternal parameterValue,
        DocumentStatusTransitionParameter[] parameters)
    {
        DocumentStatusTransitionParameter parameter = ToParameter(parameterValue, parameters);

        DocumentStatusTransitionParameterValue result = parameterValue switch
        {
            DocumentCommentStatusTransitionParameterValueInternal v =>
                DocumentCommentStatusTransitionParameterValueInternalConverter.ToDomain(parameter, v),

            DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal v =>
                DocumentCommentWithAttachmentsStatusTransitionParameterValueInternalConverter.ToDomain(parameter, v),

            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };

        return result;
    }

    private static DocumentStatusTransitionParameter ToParameter(
        DocumentStatusTransitionParameterValueInternal parameterValue,
        DocumentStatusTransitionParameter[] parameters)
    {
        DocumentStatusTransitionParameterKind kind = parameterValue switch
        {
            DocumentCommentStatusTransitionParameterValueInternal =>
                DocumentStatusTransitionParameterKind.Comment,

            DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal =>
                DocumentStatusTransitionParameterKind.CommentWithAttachments,

            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };

        DocumentStatusTransitionParameter result = parameters.Single(p => p.Kind == kind);

        return result;
    }
}
