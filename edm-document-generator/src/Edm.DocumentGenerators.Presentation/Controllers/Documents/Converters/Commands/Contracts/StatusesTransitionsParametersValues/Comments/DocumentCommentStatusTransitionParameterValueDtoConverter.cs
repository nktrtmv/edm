using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.StatusesTransitionsParametersValues.Comments;

internal static class DocumentCommentStatusTransitionParameterValueDtoConverter
{
    internal static DocumentStatusTransitionParameterValueDto FromInternal(DocumentCommentStatusTransitionParameterValueInternal parameterValue)
    {
        var comment = new DocumentCommentStatusTransitionParameterValueDto
        {
            Comment = parameterValue.Comment
        };

        var result = new DocumentStatusTransitionParameterValueDto
        {
            Comment = comment
        };

        return result;
    }

    internal static DocumentCommentStatusTransitionParameterValueInternal ToInternal(DocumentCommentStatusTransitionParameterValueDto parameterValue)
    {
        var result = new DocumentCommentStatusTransitionParameterValueInternal(parameterValue.Comment);

        return result;
    }
}
