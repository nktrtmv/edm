using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.StatusesTransitionsParametersValues.Comments;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.StatusesTransitionsParametersValues.CommentsWithAttachments;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.StatusesTransitionsParametersValues;

internal static class DocumentStatusTransitionParameterValueDtoConverter
{
    internal static DocumentStatusTransitionParameterValueDto FromInternal(DocumentStatusTransitionParameterValueInternal parameterValue)
    {
        DocumentStatusTransitionParameterValueDto result = parameterValue switch
        {
            DocumentCommentStatusTransitionParameterValueInternal v =>
                DocumentCommentStatusTransitionParameterValueDtoConverter.FromInternal(v),

            DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal v =>
                DocumentCommentWithAttachmentsStatusTransitionParameterValueDtoConverter.FromInternal(v),

            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };

        return result;
    }

    internal static DocumentStatusTransitionParameterValueInternal ToInternal(DocumentStatusTransitionParameterValueDto parameterValue)
    {
        DocumentStatusTransitionParameterValueInternal result = parameterValue.ValueCase switch
        {
            DocumentStatusTransitionParameterValueDto.ValueOneofCase.Comment =>
                DocumentCommentStatusTransitionParameterValueDtoConverter.ToInternal(parameterValue.Comment),

            DocumentStatusTransitionParameterValueDto.ValueOneofCase.CommentWithAttachments =>
                DocumentCommentWithAttachmentsStatusTransitionParameterValueDtoConverter.ToInternal(parameterValue.CommentWithAttachments),

            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };

        return result;
    }
}
