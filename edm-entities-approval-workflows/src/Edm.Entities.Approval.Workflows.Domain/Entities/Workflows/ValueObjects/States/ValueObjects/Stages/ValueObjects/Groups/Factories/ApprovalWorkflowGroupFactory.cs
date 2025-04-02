using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.Factories;

public static class ApprovalWorkflowGroupFactory
{
    public static ApprovalWorkflowGroup CreateNew(string name, ApprovalWorkflowApprovalGroup approvalGroup)
    {
        var id = Id<ApprovalWorkflowGroup>.CreateNew();

        ApprovalWorkflowAssignment[] assignments = Array.Empty<ApprovalWorkflowAssignment>();

        ApprovalWorkflowGroup result = CreateFromDb(id, name, approvalGroup, assignments, ApprovalWorkflowGroupStatus.NotStarted);

        return result;
    }

    public static ApprovalWorkflowGroup CreateFrom(string name, ApprovalWorkflowApprovalGroup approvalGroup, ApprovalWorkflowGroupStatus status)
    {
        var id = Id<ApprovalWorkflowGroup>.CreateNew();

        ApprovalWorkflowAssignment[] assignments = Array.Empty<ApprovalWorkflowAssignment>();

        ApprovalWorkflowGroup result = CreateFromDb(id, name, approvalGroup, assignments, status);

        return result;
    }

    public static ApprovalWorkflowGroup CreateFromDb(
        Id<ApprovalWorkflowGroup> id,
        string name,
        ApprovalWorkflowApprovalGroup approvalGroup,
        ApprovalWorkflowAssignment[] assignments,
        ApprovalWorkflowGroupStatus status)
    {
        var result = new ApprovalWorkflowGroup(id, name, approvalGroup, assignments, status);

        return result;
    }
}
