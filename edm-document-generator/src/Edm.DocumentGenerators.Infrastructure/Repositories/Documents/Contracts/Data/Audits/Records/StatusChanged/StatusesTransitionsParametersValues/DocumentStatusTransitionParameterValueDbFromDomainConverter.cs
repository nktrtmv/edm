using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues.Comments;
using
    Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues.CommentsWithAttachments;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues;

internal static class DocumentStatusTransitionParameterValueDbFromDomainConverter
{
    internal static DocumentStatusTransitionParameterValueDb FromDomain(DocumentStatusTransitionParameterValue parameterValue)
    {
        DocumentStatusTransitionParameterValueDb result = parameterValue switch
        {
            DocumentCommentStatusTransitionParameterValue v => ToComment(v),
            DocumentCommentWithAttachmentsStatusTransitionParameterValue v => ToCommentWithAttachments(v),
            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };

        return result;
    }

    private static DocumentStatusTransitionParameterValueDb ToComment(DocumentCommentStatusTransitionParameterValue parameterValue)
    {
        DocumentCommentStatusTransitionParameterValueDb comment =
            DocumentCommentStatusTransitionParameterValueDbConverter.FromDomain(parameterValue);

        var result = new DocumentStatusTransitionParameterValueDb
        {
            Comment = comment
        };

        return result;
    }

    private static DocumentStatusTransitionParameterValueDb ToCommentWithAttachments(DocumentCommentWithAttachmentsStatusTransitionParameterValue parameterValue)
    {
        DocumentCommentWithAttachmentsStatusTransitionParameterValueDb commentWithAttachments =
            DocumentCommentWithAttachmentsStatusTransitionParameterValueDbConverter.FromDomain(parameterValue);

        var result = new DocumentStatusTransitionParameterValueDb
        {
            CommentWithAttachments = commentWithAttachments
        };

        return result;
    }
}
