using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get.Contracts;

internal static class GetDocumentClassificationQueryInternalResponseConverter
{
    public static GetDocumentClassificationQueryInternalResponse FromDomain(DocumentClassification documentClassification)
    {
        DocumentClassificationReadModelInternal documentClassifierSubset = DocumentClassificationReadModelInternalConverter.FromDomain(documentClassification);

        var response = new GetDocumentClassificationQueryInternalResponse(documentClassifierSubset);

        return response;
    }
}
