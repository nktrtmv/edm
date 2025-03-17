using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues.Inheritors.CommentsWithAttachments;

internal static class DocumentCommentWithAttachmentsStatusTransitionParameterValueBffConverter
{
    internal static DocumentCommentWithAttachmentsStatusTransitionParameterValueDto ToDto(DocumentCommentWithAttachmentsStatusTransitionParameterValueBff value)
    {
        var result = new DocumentCommentWithAttachmentsStatusTransitionParameterValueDto
        {
            Comment = value.Comment,
            AttachmentsIds = { value.AttachmentsIds }
        };

        return result;
    }
}
