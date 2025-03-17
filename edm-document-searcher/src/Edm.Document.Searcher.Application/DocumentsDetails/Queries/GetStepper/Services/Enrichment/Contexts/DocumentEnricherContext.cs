using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain.Enrichers;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;

internal sealed class DocumentEnricherContext(DocumentExternal document, DocumentWorkflows workflows) : EnrichersContext
{
    public DocumentExternal Document { get; } = document;
    public DocumentWorkflows Workflows { get; } = workflows;
}
