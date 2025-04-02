namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds.Contracts;

public sealed class DocumentKindBff
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
