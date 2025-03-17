using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests;

public abstract class EntitiesApprovalWorkflowsRequestInternal : IRequest
{
    protected EntitiesApprovalWorkflowsRequestInternal(Id<ApprovalWorkflowInternal> workflowId)
    {
        WorkflowId = workflowId;
    }

    internal Id<ApprovalWorkflowInternal> WorkflowId { get; }
}
