using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Actualizers;

public static class ApprovalWorkflowAssignmentsActualizer
{
    public static void Actualize(ApprovalWorkflowAssignment[] assignments, ApprovalWorkflow workflow, ApprovalWorkflowStage activeStage)
    {
        bool shallBeSkipped = workflow.Parameters.Options.AutoInProgressAssignmentsIsDisabled &&
            activeStage.Type is ApprovalWorkflowStageType.ParallelAny;

        if (shallBeSkipped)
        {
            return;
        }

        ApprovalWorkflowAssignment[] activeAssignments = assignments
            .Where(a => a.IsActive)
            .ToArray();

        int activeParticipantsCount = activeAssignments
            .Select(a => a.ExecutorId)
            .Distinct()
            .Count();

        ApprovalWorkflowAssignmentStatus status = activeParticipantsCount == 1
            ? ApprovalWorkflowAssignmentStatus.InProgress
            : ApprovalWorkflowAssignmentStatus.NotStarted;

        foreach (ApprovalWorkflowAssignment assignment in activeAssignments)
        {
            ApprovalWorkflowAssignmentStateUpdater.SetStatus(assignment, status);
        }
    }
}
