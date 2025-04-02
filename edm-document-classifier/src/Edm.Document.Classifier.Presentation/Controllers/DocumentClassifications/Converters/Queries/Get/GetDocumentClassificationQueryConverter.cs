using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Get;

internal static class GetDocumentClassificationQueryConverter
{
    internal static GetDocumentClassificationQueryInternal ToInternal(GetDocumentClassificationQuery query)
    {
        var result = new GetDocumentClassificationQueryInternal(query.DocumentTemplateId);

        return result;
    }
}
