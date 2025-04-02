using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues.
    CommentsWithAttachments;

internal static class DocumentCommentWithAttachmentsStatusTransitionParameterValueDbConverter
{
    internal static DocumentCommentWithAttachmentsStatusTransitionParameterValueDb FromDomain(DocumentCommentWithAttachmentsStatusTransitionParameterValue parameterValue)
    {
        string[] attachmentsIds = parameterValue.AttachmentsIds.Select(IdConverterTo.ToString).ToArray();

        var result = new DocumentCommentWithAttachmentsStatusTransitionParameterValueDb
        {
            Comment = parameterValue.Comment,
            AttachmentsIds = { attachmentsIds }
        };

        return result;
    }

    internal static DocumentCommentWithAttachmentsStatusTransitionParameterValue ToDomain(
        DocumentCommentWithAttachmentsStatusTransitionParameterValueDb parameterValue,
        DocumentStatusTransitionParameter[] parameters)
    {
        DocumentStatusTransitionParameter parameter = parameters.Single(p => p.Kind is DocumentStatusTransitionParameterKind.CommentWithAttachments);

        Id<Attachment>[] attachmentsIds = parameterValue.AttachmentsIds.Select(IdConverterFrom<Attachment>.FromString).ToArray();

        var result = new DocumentCommentWithAttachmentsStatusTransitionParameterValue(parameter, parameterValue.Comment, attachmentsIds);

        return result;
    }
}
