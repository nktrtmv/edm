using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents;

public sealed class GetDocumentsQueryInternalResponseSearchDocument
{
    public GetDocumentsQueryInternalResponseSearchDocument(
        Id<GetDocumentsQueryInternalResponseSearchDocument> id,
        Id<SearchDocumentTemplateInternal> templateId,
        GetDocumentsQueryInternalResponseSearchDocumentAttributeValue[] attributesValues)
    {
        Id = id;
        TemplateId = templateId;
        AttributesValues = attributesValues;
    }

    public Id<GetDocumentsQueryInternalResponseSearchDocument> Id { get; }
    public Id<SearchDocumentTemplateInternal> TemplateId { get; }
    public GetDocumentsQueryInternalResponseSearchDocumentAttributeValue[] AttributesValues { get; }
}
