namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;

public sealed class DocumentClassifierSubsetBff
{
    public required string[] BusinessSegmentIds { get; init; }
    public required DocumentClassifierSubsetBffDocumentCategory DocumentCategory { get; init; }
}
