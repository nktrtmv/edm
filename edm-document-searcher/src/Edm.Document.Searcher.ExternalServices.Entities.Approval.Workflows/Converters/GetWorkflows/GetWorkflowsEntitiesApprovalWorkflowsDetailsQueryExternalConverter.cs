using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows;

internal static class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternalConverter
{
    internal static GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery ToDto(Id<EntitiesApprovalWorkflowExternal>[] ids)
    {
        string[] workflowsIds = ids.Select(IdConverterTo.ToString).ToArray();

        var result = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery
        {
            WorkflowsIds = { workflowsIds }
        };

        return result;
    }
}
