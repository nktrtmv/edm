using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories.Contracts;

public sealed class GetDocumentCategoriesQueryBffResponse
{
    public required CollectionQueryResponse<DocumentCategoryBff> DocumentCategories { get; init; }
}
