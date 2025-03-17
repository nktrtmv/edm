using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.
    CommentsWithAttachments;

internal static class DocumentCommentWithAttachmentsStatusTransitionParameterValueInternalConverter
{
    internal static DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal FromDomain(
        DocumentCommentWithAttachmentsStatusTransitionParameterValue parameterValue)
    {
        Id<DocumentAttachmentInternal>[] attachmentsIds = parameterValue.AttachmentsIds
            .Select(IdConverterFrom<DocumentAttachmentInternal>.From)
            .ToArray();

        var result = new DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal(parameterValue.Comment, attachmentsIds);

        return result;
    }

    internal static DocumentCommentWithAttachmentsStatusTransitionParameterValue ToDomain(
        DocumentStatusTransitionParameter parameter,
        DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal parameterValue)
    {
        Id<Attachment>[] attachmentsIds = parameterValue.AttachmentsIds.Select(IdConverterFrom<Attachment>.From).ToArray();

        var result = new DocumentCommentWithAttachmentsStatusTransitionParameterValue(parameter, parameterValue.Comment, attachmentsIds);

        return result;
    }
}
