namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories.Contracts;

public sealed class DocumentCategoryBff
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
