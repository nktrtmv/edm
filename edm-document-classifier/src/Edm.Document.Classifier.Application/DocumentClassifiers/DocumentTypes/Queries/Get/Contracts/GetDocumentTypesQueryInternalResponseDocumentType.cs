namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;

public sealed class GetDocumentTypesQueryInternalResponseDocumentType
{
    public GetDocumentTypesQueryInternalResponseDocumentType(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
}
