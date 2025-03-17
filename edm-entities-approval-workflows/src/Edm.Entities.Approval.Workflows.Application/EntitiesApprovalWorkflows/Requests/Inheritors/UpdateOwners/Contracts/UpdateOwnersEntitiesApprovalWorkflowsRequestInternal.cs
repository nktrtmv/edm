using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateOwners.Contracts;

public sealed class UpdateOwnersEntitiesApprovalWorkflowsRequestInternal : EntitiesApprovalWorkflowsRequestInternal
{
    public UpdateOwnersEntitiesApprovalWorkflowsRequestInternal(
        Id<ApprovalWorkflowInternal> workflowId,
        Id<EmployeeInternal> ownerId) : base(workflowId)
    {
        OwnerId = ownerId;
    }

    internal Id<EmployeeInternal> OwnerId { get; }
}
