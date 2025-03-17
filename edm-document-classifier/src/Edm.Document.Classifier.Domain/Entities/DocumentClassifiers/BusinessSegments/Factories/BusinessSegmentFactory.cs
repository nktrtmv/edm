using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Formatter;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments.Factories;

public static class BusinessSegmentFactory
{
    public static BusinessSegment CreateFrom(
        string id,
        string systemName,
        string name,
        Usage usage = Usage.Available)
    {
        Id<BusinessSegment> businessSegmentId = IdConverterFrom<BusinessSegment>.FromString(id);

        string enrichedName = UsageFormatter.Format(name, usage);

        var result = new BusinessSegment(businessSegmentId, systemName, enrichedName, string.Empty, usage);

        return result;
    }
}
