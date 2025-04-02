using Edm.Document.Searcher.Application.Documents.Events.Signing.Events.ContractorSigned.Contracts;
using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters.ContractorSigned;

internal static class ContractorSignedEntitiesSigningWorkflowsEventConverter
{
    internal static ContractorSignedEntitiesSigningWorkflowsEventInternal ToInternal(
        Id<SearchDocumentInternal> documentId,
        string domainId)
    {
        var result = new ContractorSignedEntitiesSigningWorkflowsEventInternal(documentId, domainId);

        return result;
    }
}
