using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Fetchers.Approval;

internal sealed class ApprovalWorkflowDocumentWorkflowsFetcher(IApprovalWorkflowsClient details)
{
    internal async Task<EntitiesApprovalWorkflowExternal[]> Get(DocumentExternal document, CancellationToken cancellationToken)
    {
        Id<EntitiesApprovalWorkflowExternal>[] workflowsIds = document.ApprovalData.Workflows
            .Select(d => IdConverterFrom<EntitiesApprovalWorkflowExternal>.From(d.Id))
            .ToArray();

        EntitiesApprovalWorkflowExternal[] result = await details.GetWorkflows(workflowsIds, cancellationToken);

        return result;
    }
}
