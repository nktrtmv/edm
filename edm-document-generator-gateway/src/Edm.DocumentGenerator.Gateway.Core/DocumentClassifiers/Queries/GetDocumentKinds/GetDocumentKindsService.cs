using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds;

public sealed class GetDocumentKindsService
{
    private readonly DocumentClassifierService.DocumentClassifierServiceClient _documentClassifierServiceClient;

    public GetDocumentKindsService(DocumentClassifierService.DocumentClassifierServiceClient documentClassifierServiceClient)
    {
        _documentClassifierServiceClient = documentClassifierServiceClient;
    }

    public async Task<GetDocumentKindsQueryBffResponse> Get(GetDocumentKindsQueryBff queryBff, CancellationToken cancellationToken)
    {
        var query = new GetDocumentKindsQuery
        {
            DocumentCategoryId = queryBff.DocumentCategoryId,
            DocumentTypeId = queryBff.DocumentTypeId
        };

        var response = await _documentClassifierServiceClient
            .GetDocumentKindsAsync(query, cancellationToken: cancellationToken);

        DocumentKindBff[] kindsBff = response.DocumentKinds.Select(DocumentKindBffConverter.ToBff)
            .ToArray();

        CollectionQueryResponse<DocumentKindBff> collectionQueryResponse = CollectionQueryResponseConverter.ToBff(kindsBff);

        var responseBff = new GetDocumentKindsQueryBffResponse
        {
            DocumentKinds = collectionQueryResponse
        };

        return responseBff;
    }
}
