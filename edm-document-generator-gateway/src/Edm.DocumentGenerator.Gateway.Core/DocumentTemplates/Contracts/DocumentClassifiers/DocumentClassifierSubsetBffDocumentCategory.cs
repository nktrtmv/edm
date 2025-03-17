namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;

public sealed class DocumentClassifierSubsetBffDocumentCategory
{
    public required string DocumentCategoryId { get; init; }
    public DocumentClassifierSubsetBffDocumentType[] DocumentTypes { get; init; } = Array.Empty<DocumentClassifierSubsetBffDocumentType>();
}
