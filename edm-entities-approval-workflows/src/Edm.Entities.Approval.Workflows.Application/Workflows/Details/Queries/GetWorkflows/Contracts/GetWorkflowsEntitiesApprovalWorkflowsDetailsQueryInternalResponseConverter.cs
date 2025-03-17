using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts;

internal static class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseConverter
{
    internal static GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse FromDomain(ApprovalWorkflow[] response)
    {
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow[] workflows =
            response.Select(GetEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflowConverter.FromDomain).ToArray();

        var result = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse(workflows);

        return result;
    }
}
