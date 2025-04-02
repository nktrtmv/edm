namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes.Contracts;

public sealed class DocumentTypeBff
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
