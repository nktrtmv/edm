using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Fetchers.Signing;

public sealed class SigningWorkflowDocumentWorkflowsFetcher
{
    public SigningWorkflowDocumentWorkflowsFetcher(ISigningWorkflowsDetailsClient details)
    {
        Details = details;
    }

    private ISigningWorkflowsDetailsClient Details { get; }

    internal async Task<SigningWorkflowExternal[]> Get(DocumentDetailedDto document, CancellationToken cancellationToken)
    {
        string[] ids = document.SigningData.Workflows.Select(w => w.Id).ToArray();

        var request = new GetWorkflowsSigningWorkflowDetailsQueryExternal(ids);

        var response = await Details.GetWorkflows(request, cancellationToken);

        SigningWorkflowExternal[] result = response.Workflows;

        return result;
    }
}
