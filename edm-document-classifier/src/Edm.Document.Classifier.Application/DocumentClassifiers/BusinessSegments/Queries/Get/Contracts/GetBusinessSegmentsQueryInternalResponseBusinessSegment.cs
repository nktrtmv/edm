namespace Edm.Document.Classifier.Application.DocumentClassifiers.BusinessSegments.Queries.Get.Contracts;

public sealed class GetBusinessSegmentsQueryInternalResponseBusinessSegment
{
    public GetBusinessSegmentsQueryInternalResponseBusinessSegment(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
}
