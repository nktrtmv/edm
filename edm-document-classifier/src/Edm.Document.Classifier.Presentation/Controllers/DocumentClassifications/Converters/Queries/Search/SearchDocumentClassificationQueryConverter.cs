using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Search;

internal static class SearchDocumentClassificationQueryConverter
{
    internal static SearchDocumentClassificationQueryInternal ToInternal(SearchDocumentClassificationQuery query)
    {
        var result = new SearchDocumentClassificationQueryInternal(query.BusinessSegmentId, query.DocumentCategoryId, query.DocumentTypeId, query.DocumentKindId);

        return result;
    }
}
