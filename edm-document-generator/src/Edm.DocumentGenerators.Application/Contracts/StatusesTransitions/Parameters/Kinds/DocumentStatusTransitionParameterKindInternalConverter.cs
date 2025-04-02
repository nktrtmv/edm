using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters.Kinds;

internal static class DocumentStatusTransitionParameterKindInternalConverter
{
    internal static DocumentStatusTransitionParameterKindInternal FromDomain(DocumentStatusTransitionParameterKind kind)
    {
        DocumentStatusTransitionParameterKindInternal result = kind switch
        {
            DocumentStatusTransitionParameterKind.Comment => DocumentStatusTransitionParameterKindInternal.Comment,
            DocumentStatusTransitionParameterKind.CommentWithAttachments => DocumentStatusTransitionParameterKindInternal.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static DocumentStatusTransitionParameterKind ToDomain(DocumentStatusTransitionParameterKindInternal kind)
    {
        DocumentStatusTransitionParameterKind result = kind switch
        {
            DocumentStatusTransitionParameterKindInternal.Comment => DocumentStatusTransitionParameterKind.Comment,
            DocumentStatusTransitionParameterKindInternal.CommentWithAttachments => DocumentStatusTransitionParameterKind.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
