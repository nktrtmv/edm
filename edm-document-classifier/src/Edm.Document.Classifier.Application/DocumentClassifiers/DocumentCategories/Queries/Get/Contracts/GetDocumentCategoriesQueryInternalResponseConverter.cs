using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentCategories.Queries.Get.Contracts;

internal static class GetDocumentCategoriesQueryInternalResponseConverter
{
    public static GetDocumentCategoriesQueryInternalResponse FromDomain(DocumentCategory[] documentCategories)
    {
        GetDocumentCategoriesQueryInternalResponseDocumentCategory[] documentCategoriesInternal = documentCategories
            .Select(c => new GetDocumentCategoriesQueryInternalResponseDocumentCategory(c.Id.ToString(), c.Name, c.Description, c.SystemName))
            .ToArray();

        var response = new GetDocumentCategoriesQueryInternalResponse(documentCategoriesInternal);

        return response;
    }
}
