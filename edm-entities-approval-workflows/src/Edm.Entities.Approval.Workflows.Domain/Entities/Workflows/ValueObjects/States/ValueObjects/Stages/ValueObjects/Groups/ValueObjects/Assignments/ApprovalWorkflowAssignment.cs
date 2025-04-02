using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;

public sealed class ApprovalWorkflowAssignment
{
    internal ApprovalWorkflowAssignment(
        Id<ApprovalWorkflowAssignment> id,
        Id<Employee> executorId,
        ApprovalWorkflowAssignmentStatus status,
        UtcDateTime<ApprovalWorkflowAssignment> createdDate,
        ApprovalWorkflowAssignmentCompletionDetails? completionDetails,
        Id<Employee>? authorId,
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

    public Id<ApprovalWorkflowAssignment> Id { get; }
    public Id<Employee> ExecutorId { get; }
    public ApprovalWorkflowAssignmentStatus Status { get; private set; }
    public UtcDateTime<ApprovalWorkflowAssignment> CreatedDate { get; }
    public ApprovalWorkflowAssignmentCompletionDetails? CompletionDetails { get; private set; }
    public Id<Employee>? AuthorId { get; }
    public bool IsFixed { get; private set; }

    public bool IsActive => !IsCompleted;
    public bool IsCompleted => CompletionDetails != null;

    public void SetStatus(ApprovalWorkflowAssignmentStatus status)
    {
        Status = status;
    }

    public void SetCompletionDetails(ApprovalWorkflowAssignmentCompletionDetails? completionDetails)
    {
        Status = ApprovalWorkflowAssignmentStatus.Completed;
        CompletionDetails = completionDetails;
    }

    public void SetIsFixed(bool isFixed)
    {
        IsFixed = isFixed;
    }

    public override string ToString()
    {
        return $"{{ Id: {Id}, ExecutorId: {ExecutorId}, Status: {Status}, CompletionDetails: {CompletionDetails} }}";
    }
}
