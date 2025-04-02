using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments;

public sealed class GetBusinessSegmentsService
{
    private readonly DocumentClassifierService.DocumentClassifierServiceClient _documentClassifierServiceClient;

    public GetBusinessSegmentsService(DocumentClassifierService.DocumentClassifierServiceClient documentClassifierServiceClient)
    {
        _documentClassifierServiceClient = documentClassifierServiceClient;
    }

    public async Task<GetBusinessSegmentsQueryBffResponse> Get(GetBusinessSegmentsQueryBff queryBff, CancellationToken cancellationToken)
    {
        var response = await _documentClassifierServiceClient
            .GetBusinessSegmentsAsync(new GetBusinessSegmentsQuery(), cancellationToken: cancellationToken);

        BusinessSegmentBff[] segmentsBff = response.BusinessSegments.Select(BusinessSegmentBffConverter.ToBff).ToArray();

        CollectionQueryResponse<BusinessSegmentBff> collectionQueryResponse = CollectionQueryResponseConverter.ToBff(segmentsBff);

        var responseBff = new GetBusinessSegmentsQueryBffResponse
        {
            BusinessSegments = collectionQueryResponse
        };

        return responseBff;
    }
}
