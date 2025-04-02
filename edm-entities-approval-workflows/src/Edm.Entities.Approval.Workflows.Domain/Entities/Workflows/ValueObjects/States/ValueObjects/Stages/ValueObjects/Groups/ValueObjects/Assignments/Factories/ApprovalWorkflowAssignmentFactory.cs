using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Factories;

public static class ApprovalWorkflowAssignmentFactory
{
    public static ApprovalWorkflowAssignment CreateNew(
        Id<Employee> executorId,
        ApprovalWorkflowAssignmentStatus status,
        Id<Employee>? authorId = null,
        bool isFixed = false)
    {
        var id = Id<ApprovalWorkflowAssignment>.CreateNew();

        UtcDateTime<ApprovalWorkflowAssignment> createdDate = UtcDateTime<ApprovalWorkflowAssignment>.Now;

        ApprovalWorkflowAssignment result = CreateFromDb(
            id,
            executorId,
            status,
            createdDate,
            null,
            authorId,
            isFixed);

        return result;
    }

    public static ApprovalWorkflowAssignment CreateFromDb(
        Id<ApprovalWorkflowAssignment> id,
        Id<Employee> executorId,
        ApprovalWorkflowAssignmentStatus status,
        UtcDateTime<ApprovalWorkflowAssignment> createdDate,
        ApprovalWorkflowAssignmentCompletionDetails? completionDetails,
        Id<Employee>? authorId,
        bool isFixed)
    {
        var result = new ApprovalWorkflowAssignment(
            id,
            executorId,
            status,
            createdDate,
            completionDetails,
            authorId,
            isFixed);

        return result;
    }
}
