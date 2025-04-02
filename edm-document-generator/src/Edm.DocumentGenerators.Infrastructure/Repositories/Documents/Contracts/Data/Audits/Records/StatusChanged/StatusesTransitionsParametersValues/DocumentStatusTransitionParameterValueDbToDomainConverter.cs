using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues.Comments;
using
    Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues.CommentsWithAttachments;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues;

internal static class DocumentStatusTransitionParameterValueDbToDomainConverter
{
    internal static DocumentStatusTransitionParameterValue ToDomain(
        DocumentStatusTransitionParameterValueDb parameterValue,
        DocumentStatusTransitionParameter[] parameters)
    {
        DocumentStatusTransitionParameterValue result = parameterValue.ValueCase switch
        {
            DocumentStatusTransitionParameterValueDb.ValueOneofCase.Comment =>
                ToComment(parameterValue.Comment, parameters),

            DocumentStatusTransitionParameterValueDb.ValueOneofCase.CommentWithAttachments =>
                ToCommentWithAttachments(parameterValue.CommentWithAttachments, parameters),

            _ => throw new ArgumentOutOfRangeException()
        };

        return result;
    }

    private static DocumentStatusTransitionParameterValue ToComment(
        DocumentCommentStatusTransitionParameterValueDb parameterValue,
        DocumentStatusTransitionParameter[] parameters)
    {
        DocumentCommentStatusTransitionParameterValue result =
            DocumentCommentStatusTransitionParameterValueDbConverter.ToDomain(parameterValue, parameters);

        return result;
    }

    private static DocumentStatusTransitionParameterValue ToCommentWithAttachments(
        DocumentCommentWithAttachmentsStatusTransitionParameterValueDb parameterValue,
        DocumentStatusTransitionParameter[] parameters)
    {
        DocumentCommentWithAttachmentsStatusTransitionParameterValue result =
            DocumentCommentWithAttachmentsStatusTransitionParameterValueDbConverter.ToDomain(parameterValue, parameters);

        return result;
    }
}
