namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds.Contracts;

public sealed class GetDocumentKindsQueryBff
{
    public required string DocumentCategoryId { get; init; }
    public required string DocumentTypeId { get; init; }
}
