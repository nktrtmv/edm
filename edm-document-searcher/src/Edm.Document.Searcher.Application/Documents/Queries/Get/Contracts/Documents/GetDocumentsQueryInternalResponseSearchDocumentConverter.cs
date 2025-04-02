using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.Markers;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents;

internal static class GetDocumentsQueryInternalResponseSearchDocumentInternalConverter
{
    internal static GetDocumentsQueryInternalResponseSearchDocument FromDomain(SearchDocument document)
    {
        Id<GetDocumentsQueryInternalResponseSearchDocument> id =
            IdConverterFrom<GetDocumentsQueryInternalResponseSearchDocument>.From(document.Id);

        Id<SearchDocumentTemplateInternal> templateId = IdConverterFrom<SearchDocumentTemplateInternal>.From(document.TemplateId);

        GetDocumentsQueryInternalResponseSearchDocumentAttributeValue[] attributesValues =
            document.AttributesValues.Select(GetDocumentsQueryInternalResponseSearchDocumentAttributeValueConverter.FromDomain).ToArray();

        var result = new GetDocumentsQueryInternalResponseSearchDocument(id, templateId, attributesValues);

        return result;
    }
}
