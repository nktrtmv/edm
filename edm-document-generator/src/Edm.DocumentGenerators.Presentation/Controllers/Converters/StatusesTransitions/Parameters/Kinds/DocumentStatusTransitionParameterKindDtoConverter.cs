using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Parameters.Kinds;

internal static class DocumentStatusTransitionParameterKindDtoConverter
{
    internal static DocumentStatusTransitionParameterKindDto FromInternal(DocumentStatusTransitionParameterKindInternal kind)
    {
        DocumentStatusTransitionParameterKindDto result = kind switch
        {
            DocumentStatusTransitionParameterKindInternal.Comment => DocumentStatusTransitionParameterKindDto.Comment,
            DocumentStatusTransitionParameterKindInternal.CommentWithAttachments => DocumentStatusTransitionParameterKindDto.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static DocumentStatusTransitionParameterKindInternal ToInternal(DocumentStatusTransitionParameterKindDto kind)
    {
        DocumentStatusTransitionParameterKindInternal result = kind switch
        {
            DocumentStatusTransitionParameterKindDto.Comment => DocumentStatusTransitionParameterKindInternal.Comment,
            DocumentStatusTransitionParameterKindDto.CommentWithAttachments => DocumentStatusTransitionParameterKindInternal.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
