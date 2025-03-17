using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.Statuses;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments;

public sealed class ApprovalWorkflowAssignmentInternal
{
    public ApprovalWorkflowAssignmentInternal(
        Id<ApprovalWorkflowAssignmentInternal> id,
        Id<EmployeeInternal> executorId,
        ApprovalWorkflowAssignmentStatusInternal status,
        UtcDateTime<ApprovalWorkflowAssignmentInternal> createdDate,
        ApprovalWorkflowAssignmentCompletionDetailsInternal? completionDetails,
        Id<EmployeeInternal>? authorId,
        bool isFixed)
    {
        Id = id;
        ExecutorId = executorId;
        Status = status;
        CreatedDate = createdDate;
        CompletionDetails = completionDetails;
        AuthorId = authorId;
        IsFixed = isFixed;
    }

    public Id<ApprovalWorkflowAssignmentInternal> Id { get; }
    public Id<EmployeeInternal> ExecutorId { get; }
    public ApprovalWorkflowAssignmentStatusInternal Status { get; }
    public UtcDateTime<ApprovalWorkflowAssignmentInternal> CreatedDate { get; }
    public ApprovalWorkflowAssignmentCompletionDetailsInternal? CompletionDetails { get; }
    public Id<EmployeeInternal>? AuthorId { get; }
    public bool IsFixed { get; }
}
