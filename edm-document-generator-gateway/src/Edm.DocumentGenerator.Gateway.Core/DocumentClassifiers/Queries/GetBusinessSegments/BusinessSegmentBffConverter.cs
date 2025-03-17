using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments;

internal static class BusinessSegmentBffConverter
{
    public static BusinessSegmentBff ToBff(GetBusinessSegmentsQueryResponseBusinessSegment businessSegment)
    {
        var result = new BusinessSegmentBff
        {
            Id = businessSegment.Id,
            Description = businessSegment.Description,
            Name = businessSegment.Name
        };

        return result;
    }
}
