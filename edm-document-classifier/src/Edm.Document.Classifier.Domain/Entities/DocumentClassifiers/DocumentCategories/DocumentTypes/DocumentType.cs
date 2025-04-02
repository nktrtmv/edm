using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;

public sealed class DocumentType : ITypedReference
{
    internal DocumentType(Id<DocumentType> id, string name, string description, Usage usage, DocumentKind[] documentKinds)
    {
        Id = id;
        Name = name;
        Description = description;
        Usage = usage;
        DocumentKinds = documentKinds;
    }

    public Id<DocumentType> Id { get; }
    public string Name { get; }
    public string Description { get; }
    public Usage Usage { get; }
    public DocumentKind[] DocumentKinds { get; }
}
