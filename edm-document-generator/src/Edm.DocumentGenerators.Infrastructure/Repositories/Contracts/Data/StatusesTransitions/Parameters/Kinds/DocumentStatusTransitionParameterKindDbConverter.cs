using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions.Parameters.Kinds;

internal static class DocumentStatusTransitionParameterKindDbConverter
{
    internal static DocumentStatusTransitionParameterKindDb FromDomain(DocumentStatusTransitionParameterKind kind)
    {
        DocumentStatusTransitionParameterKindDb result = kind switch
        {
            DocumentStatusTransitionParameterKind.Comment => DocumentStatusTransitionParameterKindDb.Comment,
            DocumentStatusTransitionParameterKind.CommentWithAttachments => DocumentStatusTransitionParameterKindDb.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static DocumentStatusTransitionParameterKind ToDomain(DocumentStatusTransitionParameterKindDb kind)
    {
        DocumentStatusTransitionParameterKind result = kind switch
        {
            DocumentStatusTransitionParameterKindDb.Comment => DocumentStatusTransitionParameterKind.Comment,
            DocumentStatusTransitionParameterKindDb.CommentWithAttachments => DocumentStatusTransitionParameterKind.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
