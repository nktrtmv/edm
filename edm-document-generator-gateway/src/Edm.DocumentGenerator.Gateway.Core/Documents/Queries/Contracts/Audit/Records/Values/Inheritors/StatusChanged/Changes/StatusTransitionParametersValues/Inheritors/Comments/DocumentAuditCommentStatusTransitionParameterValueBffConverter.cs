using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.Comments;

internal static class DocumentAuditCommentStatusTransitionParameterValueBffConverter
{
    internal static DocumentAuditCommentStatusTransitionParameterValueBff FromDto(DocumentCommentStatusTransitionParameterValueDto value)
    {
        var result = new DocumentAuditCommentStatusTransitionParameterValueBff
        {
            Comment = value.Comment
        };

        return result;
    }
}
