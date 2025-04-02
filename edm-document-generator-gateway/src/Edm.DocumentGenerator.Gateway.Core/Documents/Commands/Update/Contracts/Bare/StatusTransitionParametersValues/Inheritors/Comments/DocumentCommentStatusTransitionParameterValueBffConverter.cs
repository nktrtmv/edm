using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues.Inheritors.Comments;

internal static class DocumentCommentStatusTransitionParameterValueBffConverter
{
    internal static DocumentCommentStatusTransitionParameterValueDto ToDto(DocumentCommentStatusTransitionParameterValueBff value)
    {
        var result = new DocumentCommentStatusTransitionParameterValueDto
        {
            Comment = value.Comment
        };

        return result;
    }
}
