using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;

internal static class SearchDocumentClassificationQueryInternalResponseConverter
{
    public static SearchDocumentClassificationQueryInternalResponse FromDomain(DocumentClassification[] classifications)
    {
        DocumentClassificationReadModelInternal[] classificationsForResponse =
            classifications.Select(DocumentClassificationReadModelInternalConverter.FromDomain).ToArray();

        var result = new SearchDocumentClassificationQueryInternalResponse(classificationsForResponse);

        return result;
    }
}
