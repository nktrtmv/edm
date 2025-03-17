using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentKinds;

internal static class GetDocumentKindsQueryConverter
{
    internal static GetDocumentKindsQueryInternal ToInternal(GetDocumentKindsQuery query)
    {
        var result = new GetDocumentKindsQueryInternal(query.DocumentCategoryId, query.DocumentTypeId);

        return result;
    }
}
