namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentCategories.Queries.Get.Contracts;

public sealed class GetDocumentCategoriesQueryInternalResponseDocumentCategory
{
    public GetDocumentCategoriesQueryInternalResponseDocumentCategory(string id, string name, string description, string systemName)
    {
        Id = id;
        Name = name;
        Description = description;
        SystemName = systemName;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string SystemName { get; }
}
