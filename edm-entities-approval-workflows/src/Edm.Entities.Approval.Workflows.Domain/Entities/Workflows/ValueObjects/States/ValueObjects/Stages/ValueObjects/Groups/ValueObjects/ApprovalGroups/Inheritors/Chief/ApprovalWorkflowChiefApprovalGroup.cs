using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Chief;

public sealed class ApprovalWorkflowChiefApprovalGroup : ApprovalWorkflowApprovalGroup
{
    public ApprovalWorkflowChiefApprovalGroup(Id<Employee> currentUserId)
    {
        CurrentUserId = currentUserId;
    }

    public Id<Employee> CurrentUserId { get; }

    public override string ToString()
    {
        return $"{{ {BaseToString()}, CurrentUserId: {CurrentUserId} }}";
    }
}
