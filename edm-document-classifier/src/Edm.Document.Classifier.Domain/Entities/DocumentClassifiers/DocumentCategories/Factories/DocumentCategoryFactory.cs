using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Formatter;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.Factories;

public static class DocumentCategoryFactory
{
    public static DocumentCategory CreateFrom(
        string id,
        string systemName,
        string name,
        DocumentType[] documentTypes)
    {
        DocumentCategory result = CreateFrom(id, systemName, name, Usage.Available, documentTypes);

        return result;
    }

    public static DocumentCategory CreateFrom(
        string id,
        string systemName,
        string name,
        Usage usage,
        DocumentType[] documentTypes)
    {
        Id<DocumentCategory> categoryId = IdConverterFrom<DocumentCategory>.FromString(id);

        string enrichedName = UsageFormatter.Format(name, usage);

        var result = new DocumentCategory(categoryId, systemName, enrichedName, string.Empty, usage, documentTypes);

        return result;
    }
}
