using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts;

public sealed class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal : IRequest<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse>
{
    public GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal(Id<ApprovalWorkflowInternal>[] workflowsIds)
    {
        WorkflowsIds = workflowsIds;
    }

    internal Id<ApprovalWorkflowInternal>[] WorkflowsIds { get; }
}
