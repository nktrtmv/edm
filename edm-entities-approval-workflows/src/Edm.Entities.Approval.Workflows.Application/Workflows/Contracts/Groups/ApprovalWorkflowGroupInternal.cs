using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups;

public sealed class ApprovalWorkflowGroupInternal
{
    public ApprovalWorkflowGroupInternal(
        Id<ApprovalWorkflowGroupInternal> id,
        string name,
        ApprovalWorkflowAssignmentInternal[] assignments,
        ApprovalWorkflowGroupStatusInternal status)
    {
        Id = id;
        Assignments = assignments;
        Name = name;
        Status = status;
    }

    public Id<ApprovalWorkflowGroupInternal> Id { get; }
    public ApprovalWorkflowAssignmentInternal[] Assignments { get; }
    public string Name { get; }
    public ApprovalWorkflowGroupStatusInternal Status { get; }
}
