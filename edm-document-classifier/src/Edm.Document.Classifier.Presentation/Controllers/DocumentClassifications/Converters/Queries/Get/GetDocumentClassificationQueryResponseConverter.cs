using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Converters.DocumentClassifications;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Get;

internal static class GetDocumentClassificationQueryResponseConverter
{
    internal static GetDocumentClassificationQueryResponse FromInternal(GetDocumentClassificationQueryInternalResponse response)
    {
        DocumentClassificationReadModelDto documentClassification =
            DocumentClassificationReadModelInternalConverter.FromInternal(response.DocumentClassification);

        var result = new GetDocumentClassificationQueryResponse
        {
            DocumentClassification = documentClassification
        };

        return result;
    }
}
