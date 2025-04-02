using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;

public sealed class ApprovalWorkflowGroup
{
    internal ApprovalWorkflowGroup(
        Id<ApprovalWorkflowGroup> id,
        string name,
        ApprovalWorkflowApprovalGroup approvalGroup,
        ApprovalWorkflowAssignment[] assignments,
        ApprovalWorkflowGroupStatus status)
    {
        Id = id;
        ApprovalGroup = approvalGroup;
        Name = name;
        Assignments = assignments;
        Status = status;
    }

    public Id<ApprovalWorkflowGroup> Id { get; }
    public string Name { get; }
    public ApprovalWorkflowApprovalGroup ApprovalGroup { get; }
    public ApprovalWorkflowAssignment[] Assignments { get; private set; }
    public ApprovalWorkflowGroupStatus Status { get; private set; }

    public void SetAssignments(ApprovalWorkflowAssignment[] assignments)
    {
        Assignments = assignments;
    }

    public void SetStatus(ApprovalWorkflowGroupStatus status)
    {
        Status = status;
    }

    public override string ToString()
    {
        return $"{{ Id: {Id}, Name: {Name}, Status: {Status}, ApprovalGroup: {ApprovalGroup}, AssignmentsCount: {Assignments.Length} }}";
    }
}
