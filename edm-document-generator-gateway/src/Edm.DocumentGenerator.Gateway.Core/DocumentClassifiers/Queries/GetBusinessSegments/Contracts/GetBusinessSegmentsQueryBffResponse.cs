using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments.Contracts;

public sealed class GetBusinessSegmentsQueryBffResponse
{
    public required CollectionQueryResponse<BusinessSegmentBff> BusinessSegments { get; init; }
}
