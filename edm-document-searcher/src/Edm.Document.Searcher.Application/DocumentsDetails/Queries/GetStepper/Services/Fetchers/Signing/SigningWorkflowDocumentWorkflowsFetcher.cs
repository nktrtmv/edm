using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Fetchers.Signing;

internal sealed class SigningWorkflowDocumentWorkflowsFetcher(ISigningWorkflowsDetailsClient details)
{
    internal async Task<SigningWorkflowExternal[]> Get(DocumentExternal document, CancellationToken cancellationToken)
    {
        string[] ids = document.SigningData.Workflows.Select(w => w.Id.Value).ToArray();

        GetWorkflowsSigningWorkflowDetailsQueryResponseExternal response = await details.GetWorkflows(ids, cancellationToken);

        SigningWorkflowExternal[] result = response.Workflows;

        return result;
    }
}
