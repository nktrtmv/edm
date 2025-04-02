using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues.Inheritors.Comments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues.Inheritors.CommentsWithAttachments;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues;

internal static class DocumentStatusTransitionParameterValueBffToDtoConverter
{
    public static DocumentStatusTransitionParameterValueDto ToDto(DocumentStatusTransitionParameterValueBff bff)
    {
        var result = bff switch
        {
            DocumentCommentStatusTransitionParameterValueBff comment => ToComment(comment),

            DocumentCommentWithAttachmentsStatusTransitionParameterValueBff commentWithAttachments => ToCommentWithAttachments(commentWithAttachments),

            _ => throw new ArgumentTypeOutOfRangeException(bff)
        };

        return result;
    }

    private static DocumentStatusTransitionParameterValueDto ToComment(DocumentCommentStatusTransitionParameterValueBff value)
    {
        var comment =
            DocumentCommentStatusTransitionParameterValueBffConverter.ToDto(value);

        var result = new DocumentStatusTransitionParameterValueDto
        {
            Comment = comment
        };

        return result;
    }

    private static DocumentStatusTransitionParameterValueDto ToCommentWithAttachments(DocumentCommentWithAttachmentsStatusTransitionParameterValueBff value)
    {
        var commentWithAttachments =
            DocumentCommentWithAttachmentsStatusTransitionParameterValueBffConverter.ToDto(value);

        var result = new DocumentStatusTransitionParameterValueDto
        {
            CommentWithAttachments = commentWithAttachments
        };

        return result;
    }
}
