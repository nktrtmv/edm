namespace Edm.Document.Classifier.Application.DocumentClassifiers.BusinessSegments.Queries.Get.Contracts;

public sealed class GetBusinessSegmentsQueryInternalResponse
{
    public GetBusinessSegmentsQueryInternalResponse(GetBusinessSegmentsQueryInternalResponseBusinessSegment[] businessSegments)
    {
        BusinessSegments = businessSegments;
    }

    public GetBusinessSegmentsQueryInternalResponseBusinessSegment[] BusinessSegments { get; }
}
