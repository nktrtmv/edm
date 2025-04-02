using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentTypes;

internal static class GetDocumentTypesQueryConverter
{
    internal static GetDocumentTypesQueryInternal ToInternal(GetDocumentTypesQuery query)
    {
        var result = new GetDocumentTypesQueryInternal(query.DocumentCategoryId);

        return result;
    }
}
