using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Formatter;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.Factories;

public static class DocumentTypeFactory
{
    public static DocumentType CreateFrom(
        string id,
        string name,
        DocumentKind[] documentKinds)
    {
        DocumentType result = CreateFrom(id, name, Usage.Available, documentKinds);

        return result;
    }

    public static DocumentType CreateFrom(
        string id,
        string name,
        Usage usage,
        DocumentKind[] documentKinds)
    {
        Id<DocumentType> typeId = IdConverterFrom<DocumentType>.FromString(id);

        string enrichedName = UsageFormatter.Format(name, usage);

        var result = new DocumentType(typeId, enrichedName, string.Empty, usage, documentKinds);

        return result;
    }
}
