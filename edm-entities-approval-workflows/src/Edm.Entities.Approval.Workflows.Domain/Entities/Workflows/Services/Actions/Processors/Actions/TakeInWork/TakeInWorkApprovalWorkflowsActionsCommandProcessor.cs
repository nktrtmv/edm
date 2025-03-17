using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Detectors;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators.ActionIsAvailable;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.TakeInWork;

public static class TakeInWorkApprovalWorkflowsActionsCommandProcessor
{
    public static void TakeInWork(ApprovalWorkflowActionContext context)
    {
        ActionIsAvailableEntitiesApprovalWorkflowsValidator.Validate(context, ApprovalWorkflowActionKind.TakeInWork);

        var activeGroup = ActiveGroupApprovalWorkflowsDetector.GetRequired(context.ActiveGroups, context.CurrentUserId);

        TakeInWork(activeGroup, context.CurrentUserId);
    }

    private static void TakeInWork(ApprovalWorkflowGroup group, Id<Employee> currentUserId)
    {
        foreach (var assignment in group.Assignments)
        {
            if (assignment.IsCompleted)
            {
                continue;
            }

            if (assignment.ExecutorId == currentUserId)
            {
                ApprovalWorkflowAssignmentStateUpdater.SetInProgressManually(assignment);
            }
            else
            {
                ApprovalWorkflowAssignmentStateUpdater.SetAutoCompleted(assignment);
            }
        }
    }
}
