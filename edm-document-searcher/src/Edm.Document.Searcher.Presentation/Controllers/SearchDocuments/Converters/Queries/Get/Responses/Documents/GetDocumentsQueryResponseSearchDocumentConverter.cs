using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Get.Responses.Documents.AttributesValues;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Get.Responses.Documents;

internal static class GetDocumentsQueryResponseSearchDocumentConverter
{
    internal static GetDocumentsQueryResponseSearchDocument FromInternal(GetDocumentsQueryInternalResponseSearchDocument document)
    {
        var id = IdConverterTo.ToString(document.Id);

        var templateId = IdConverterTo.ToString(document.TemplateId);

        GetDocumentsQueryResponseSearchDocumentAttributeValue[] attributesValues =
            document.AttributesValues.Select(GetDocumentsQueryResponseSearchDocumentAttributeValueFromInternalConverter.FromInternal).ToArray();

        var result = new GetDocumentsQueryResponseSearchDocument
        {
            Id = id,
            TemplateId = templateId,
            AttributesValues = { attributesValues }
        };

        return result;
    }
}
