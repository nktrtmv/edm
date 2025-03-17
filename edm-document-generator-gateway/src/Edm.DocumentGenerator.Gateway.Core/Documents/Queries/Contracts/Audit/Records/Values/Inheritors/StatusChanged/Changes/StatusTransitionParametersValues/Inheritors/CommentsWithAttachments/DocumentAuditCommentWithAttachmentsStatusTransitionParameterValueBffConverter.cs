using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.CommentsWithAttachments;

internal static class DocumentAuditCommentWithAttachmentsStatusTransitionParameterValueBffConverter
{
    internal static DocumentAuditCommentWithAttachmentsStatusTransitionParameterValueBff FromDto(
        DocumentCommentWithAttachmentsStatusTransitionParameterValueDto value,
        DocumentConversionContext context)
    {
        var attachments = value
            .AttachmentsIds
            .Select(Guid.Parse)
            .ToArray();

        var result = new DocumentAuditCommentWithAttachmentsStatusTransitionParameterValueBff
        {
            Comment = value.Comment,
            Attachments = attachments
        };

        return result;
    }
}
