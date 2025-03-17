using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;

public sealed class BusinessSegment : ITypedReference
{
    internal BusinessSegment(Id<BusinessSegment> id, string systemName, string name, string description, Usage usage)
    {
        Id = id;
        SystemName = systemName;
        Name = name;
        Description = description;
        Usage = usage;
    }

    public Id<BusinessSegment> Id { get; }
    public string SystemName { get; }
    public string Name { get; }
    public string Description { get; }
    public Usage Usage { get; }
}
