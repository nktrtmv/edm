namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentCategories.Queries.Get.Contracts;

public sealed class GetDocumentCategoriesQueryInternalResponse
{
    public GetDocumentCategoriesQueryInternalResponse(GetDocumentCategoriesQueryInternalResponseDocumentCategory[] documentCategories)
    {
        DocumentCategories = documentCategories;
    }

    public GetDocumentCategoriesQueryInternalResponseDocumentCategory[] DocumentCategories { get; }
}
