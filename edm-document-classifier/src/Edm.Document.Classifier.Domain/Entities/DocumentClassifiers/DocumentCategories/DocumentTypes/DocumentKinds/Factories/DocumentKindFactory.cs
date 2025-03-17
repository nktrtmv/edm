using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Formatter;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds.Factories;

public static class DocumentKindFactory
{
    public static DocumentKind CreateFrom(string id, string name)
    {
        DocumentKind result = CreateFrom(id, name, Usage.Available);

        return result;
    }

    public static DocumentKind CreateFrom(string id, string name, Usage usage)
    {
        Id<DocumentKind> kindId = IdConverterFrom<DocumentKind>.FromString(id);

        string enrichedName = UsageFormatter.Format(name, usage);

        var result = new DocumentKind(kindId, enrichedName, string.Empty, usage);

        return result;
    }
}
