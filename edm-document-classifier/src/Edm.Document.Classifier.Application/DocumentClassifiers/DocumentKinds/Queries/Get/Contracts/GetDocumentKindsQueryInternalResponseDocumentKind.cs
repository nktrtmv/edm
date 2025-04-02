namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;

public sealed class GetDocumentKindsQueryInternalResponseDocumentKind
{
    public GetDocumentKindsQueryInternalResponseDocumentKind(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
}
