using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes;

public sealed class GetDocumentTypesService
{
    private readonly DocumentClassifierService.DocumentClassifierServiceClient _documentClassifierServiceClient;

    public GetDocumentTypesService(DocumentClassifierService.DocumentClassifierServiceClient documentClassifierServiceClient)
    {
        _documentClassifierServiceClient = documentClassifierServiceClient;
    }

    public async Task<GetDocumentTypesQueryBffResponse> Get(GetDocumentTypesQueryBff queryBff, CancellationToken cancellationToken)
    {
        var query = new GetDocumentTypesQuery
        {
            DocumentCategoryId = queryBff.DocumentCategoryId
        };

        var response = await _documentClassifierServiceClient
            .GetDocumentTypesAsync(query, cancellationToken: cancellationToken);

        DocumentTypeBff[] typesBff = response.DocumentTypes.Select(DocumentTypeBffConverter.ToBff)
            .ToArray();

        CollectionQueryResponse<DocumentTypeBff> documentTypes = CollectionQueryResponseConverter.ToBff(typesBff);

        var responseBff = new GetDocumentTypesQueryBffResponse
        {
            DocumentTypes = documentTypes
        };

        return responseBff;
    }
}
