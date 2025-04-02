using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories;

public sealed class GetDocumentCategoriesService
{
    private readonly DocumentClassifierService.DocumentClassifierServiceClient _documentClassifierServiceClient;

    public GetDocumentCategoriesService(DocumentClassifierService.DocumentClassifierServiceClient documentClassifierServiceClient)
    {
        _documentClassifierServiceClient = documentClassifierServiceClient;
    }

    public async Task<GetDocumentCategoriesQueryBffResponse> Get(GetDocumentCategoriesQueryBff queryBff, CancellationToken cancellationToken)
    {
        var response = await _documentClassifierServiceClient
            .GetDocumentCategoriesAsync(new GetDocumentCategoriesQuery(), cancellationToken: cancellationToken);

        DocumentCategoryBff[] categoriesBff = response.DocumentCategories.Select(DocumentCategoryBffConverter.ToBff)
            .ToArray();

        CollectionQueryResponse<DocumentCategoryBff> collectionQueryResponse = CollectionQueryResponseConverter.ToBff(categoriesBff);

        var responseBff = new GetDocumentCategoriesQueryBffResponse
        {
            DocumentCategories = collectionQueryResponse
        };

        return responseBff;
    }
}
