namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;

internal sealed class DocumentConversionContext(
    DocumentEnricherContext documentEnricherContext)
{
    public DocumentEnricherContext DocumentEnricherContext { get; } = documentEnricherContext;
}
