using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;

public sealed class DocumentKind : ITypedReference
{
    internal DocumentKind(Id<DocumentKind> id, string name, string description, Usage usage)
    {
        Id = id;
        Name = name;
        Description = description;
        Usage = usage;
    }

    public Id<DocumentKind> Id { get; }
    public string Name { get; }
    public string Description { get; }
    public Usage Usage { get; }
}
