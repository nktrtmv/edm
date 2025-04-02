namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;

public sealed class DocumentClassifierSubsetBffDocumentType
{
    public required string DocumentTypeId { get; init; }
    public string[] DocumentKindIds { get; init; } = Array.Empty<string>();
}
