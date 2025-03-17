namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment.Context;

internal sealed class GetAllDocumentsQueryResponseDocumentBffContext
{
    public GetAllDocumentsQueryResponseDocumentBffContext(GetAllDocumentsQueryResponseDocumentBffEnricher enricher)
    {
        Enricher = enricher;
    }

    public GetAllDocumentsQueryResponseDocumentBffEnricher Enricher { get; }
}
