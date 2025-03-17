using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Converters.DocumentClassifications;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Search;

internal static class SearchDocumentClassificationQueryResponseConverter
{
    internal static SearchDocumentClassificationQueryResponse FromInternal(SearchDocumentClassificationQueryInternalResponse response)
    {
        DocumentClassificationReadModelDto[] documentClassifications =
            response.DocumentClassifications.Select(DocumentClassificationReadModelInternalConverter.FromInternal).ToArray();

        var result = new SearchDocumentClassificationQueryResponse
        {
            DocumentClassifications = { documentClassifications }
        };

        return result;
    }
}
