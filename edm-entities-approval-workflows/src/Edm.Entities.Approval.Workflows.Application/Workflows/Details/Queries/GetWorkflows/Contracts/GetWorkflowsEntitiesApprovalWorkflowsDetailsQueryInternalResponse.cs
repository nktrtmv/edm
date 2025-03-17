using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts;

public sealed class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse
{
    public GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse(GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow[] workflows)
    {
        Workflows = workflows;
    }

    public GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow[] Workflows { get; }
}
