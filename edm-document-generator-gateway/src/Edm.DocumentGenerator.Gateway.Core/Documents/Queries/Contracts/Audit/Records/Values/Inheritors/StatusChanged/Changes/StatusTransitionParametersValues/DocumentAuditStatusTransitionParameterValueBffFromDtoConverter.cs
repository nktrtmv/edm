using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.Comments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.CommentsWithAttachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues;

internal static class DocumentAuditStatusTransitionParameterValueBffFromDtoConverter
{
    public static DocumentAuditStatusTransitionParameterValueBff FromDto(DocumentStatusTransitionParameterValueDto dto, DocumentConversionContext context)
    {
        DocumentAuditStatusTransitionParameterValueBff result = dto.ValueCase switch
        {
            DocumentStatusTransitionParameterValueDto.ValueOneofCase.Comment =>
                DocumentAuditCommentStatusTransitionParameterValueBffConverter.FromDto(dto.Comment),

            DocumentStatusTransitionParameterValueDto.ValueOneofCase.CommentWithAttachments =>
                DocumentAuditCommentWithAttachmentsStatusTransitionParameterValueBffConverter.FromDto(dto.CommentWithAttachments, context),

            _ => throw new ArgumentTypeOutOfRangeException(dto)
        };

        return result;
    }
}
