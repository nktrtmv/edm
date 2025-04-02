using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.BusinessSegments.Queries.Get.Contracts;

internal static class GetBusinessSegmentsQueryInternalResponseConverter
{
    public static GetBusinessSegmentsQueryInternalResponse FromDomain(BusinessSegment[] businessSegments)
    {
        GetBusinessSegmentsQueryInternalResponseBusinessSegment[] businessSegmentsInternal = businessSegments
            .Select(s => new GetBusinessSegmentsQueryInternalResponseBusinessSegment(s.Id.ToString(), s.Name, s.Description))
            .ToArray();


        var response = new GetBusinessSegmentsQueryInternalResponse(businessSegmentsInternal);

        return response;
    }
}
