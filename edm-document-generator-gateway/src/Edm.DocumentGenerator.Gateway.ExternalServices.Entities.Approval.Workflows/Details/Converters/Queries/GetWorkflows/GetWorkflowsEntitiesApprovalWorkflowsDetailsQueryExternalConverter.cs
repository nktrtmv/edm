using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows;

internal static class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternalConverter
{
    internal static GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery ToDto(GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal query)
    {
        string[] workflowsIds = query.Ids.ToArray();

        var result = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery
        {
            WorkflowsIds = { workflowsIds }
        };

        return result;
    }
}
