using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

internal sealed class DocumentConversionContext(
    DocumentDetailedBffEnricher enricher,
    Dictionary<string, string> attributesFrontMetadata,
    DocumentEnricherContext documentEnricherContext)
{
    public Dictionary<string, string> AttributesFrontMetadata { get; } = attributesFrontMetadata;
    public DocumentDetailedBffEnricher Enricher { get; } = enricher;
    public DocumentEnricherContext DocumentEnricherContext { get; } = documentEnricherContext;
}
