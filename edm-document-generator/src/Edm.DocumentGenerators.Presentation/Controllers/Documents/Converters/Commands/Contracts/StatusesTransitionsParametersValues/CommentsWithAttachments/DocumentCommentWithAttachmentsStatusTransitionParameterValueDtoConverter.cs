using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.StatusesTransitionsParametersValues.CommentsWithAttachments;

internal static class DocumentCommentWithAttachmentsStatusTransitionParameterValueDtoConverter
{
    internal static DocumentStatusTransitionParameterValueDto FromInternal(DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal parameterValue)
    {
        string[] attachmentsIds = parameterValue.AttachmentsIds.Select(IdConverterTo.ToString).ToArray();

        var commentWithAttachments = new DocumentCommentWithAttachmentsStatusTransitionParameterValueDto
        {
            Comment = parameterValue.Comment,
            AttachmentsIds = { attachmentsIds }
        };

        var result = new DocumentStatusTransitionParameterValueDto
        {
            CommentWithAttachments = commentWithAttachments
        };

        return result;
    }

    internal static DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal ToInternal(
        DocumentCommentWithAttachmentsStatusTransitionParameterValueDto parameterValue)
    {
        Id<DocumentAttachmentInternal>[] attachmentsIds = parameterValue.AttachmentsIds.Select(IdConverterFrom<DocumentAttachmentInternal>.FromString).ToArray();

        var result = new DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal(parameterValue.Comment, attachmentsIds);

        return result;
    }
}
