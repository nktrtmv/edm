using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;

public sealed class DocumentCategory : ITypedReference
{
    internal DocumentCategory(Id<DocumentCategory> id, string systemName, string name, string description, Usage usage, DocumentType[] documentTypes)
    {
        Id = id;
        SystemName = systemName;
        Name = name;
        Description = description;
        Usage = usage;
        DocumentTypes = documentTypes;
    }

    public Id<DocumentCategory> Id { get; }
    public string SystemName { get; }
    public string Name { get; }
    public string Description { get; }
    public Usage Usage { get; }
    public DocumentType[] DocumentTypes { get; }
}
