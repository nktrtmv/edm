using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentCategories.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentCategories;

internal static class GetDocumentCategoriesQueryResponseConverter
{
    internal static GetDocumentCategoriesQueryResponse FromInternal(GetDocumentCategoriesQueryInternalResponse internalResponse)
    {
        GetDocumentCategoriesQueryResponseDocumentCategory[] documentCategories = internalResponse.DocumentCategories.Select(
                b => new GetDocumentCategoriesQueryResponseDocumentCategory
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    SystemName = b.SystemName
                })
            .ToArray();

        var response = new GetDocumentCategoriesQueryResponse
        {
            DocumentCategories = { documentCategories }
        };

        return response;
    }
}
