using Edm.Document.Classifier.Application.DocumentClassifiers.BusinessSegments.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetBusinessSegments;

internal static class GetBusinessSegmentsQueryResponseConverter
{
    internal static GetBusinessSegmentsQueryResponse FromInternal(GetBusinessSegmentsQueryInternalResponse response)
    {
        GetBusinessSegmentsQueryResponseBusinessSegment[] businessSegments = response.BusinessSegments.Select(
                b => new GetBusinessSegmentsQueryResponseBusinessSegment
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                })
            .ToArray();

        var result = new GetBusinessSegmentsQueryResponse
        {
            BusinessSegments = { businessSegments }
        };

        return result;
    }
}
