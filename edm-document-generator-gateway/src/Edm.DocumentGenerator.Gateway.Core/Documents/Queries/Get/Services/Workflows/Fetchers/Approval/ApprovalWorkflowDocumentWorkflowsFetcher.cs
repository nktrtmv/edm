using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Fetchers.Approval;

public sealed class ApprovalWorkflowDocumentWorkflowsFetcher
{
    public ApprovalWorkflowDocumentWorkflowsFetcher(IEntitiesApprovalWorkflowsDetailsClient details)
    {
        Details = details;
    }

    private IEntitiesApprovalWorkflowsDetailsClient Details { get; }

    internal async Task<EntitiesApprovalWorkflowExternal[]> Get(DocumentDetailedDto document, CancellationToken cancellationToken)
    {
        string[] ids = document.ApprovalData.Workflows.Select(w => w.Id).ToArray();

        var request = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal(ids);

        EntitiesApprovalWorkflowExternal[] result = await Details.GetWorkflows(request, cancellationToken);

        return result;
    }
}
