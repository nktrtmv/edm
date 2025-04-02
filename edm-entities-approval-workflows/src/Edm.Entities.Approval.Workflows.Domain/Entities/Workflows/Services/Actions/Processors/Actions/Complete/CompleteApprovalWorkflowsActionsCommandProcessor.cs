using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Completers.Workflow;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Completers.Workflow.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Completers.Workflow.Stage;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Detectors.CompletedStages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Detectors.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Detectors;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators.ActionIsAvailable;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.StageChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete;

public static class CompleteApprovalWorkflowsActionsCommandProcessor
{
    public static void Complete(ApprovalWorkflowActionContext context, ApprovalWorkflowAssignmentCompletionReason completionReason, string? completionComment)
    {
        ActionIsAvailableEntitiesApprovalWorkflowsValidator.Validate(context, completionReason);

        var activeGroup = ActiveGroupApprovalWorkflowsDetector.Get(context.ActiveGroups, context.CurrentUserId);

        TryCompleteActiveGroup(activeGroup, context.CurrentUserId, context.CurrentUserIsAdmin, completionReason, completionComment);

        var participantsChangedEvent = new ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent();

        context.Workflow.ApplicationEvents.Add(participantsChangedEvent);

        var (nextStageStatus, nextWorkflowStatus) = ApprovalWorkflowStatusesDetector.Detect(completionReason);

        CompleteStages(context, nextStageStatus);

        var isAllStagesCompleted = context.Workflow.State.Stages.All(s => s.IsCompleted);

        if (!isAllStagesCompleted)
        {
            return;
        }

        ApprovalWorkflowCompleter.Complete(context, nextWorkflowStatus, completionComment);
    }

    private static void CompleteStages(ApprovalWorkflowActionContext context, ApprovalWorkflowStageStatus nextStageStatus)
    {
        var completeImmediately = nextStageStatus is ApprovalWorkflowStageStatus.ReturnedToRework or ApprovalWorkflowStageStatus.Rejected;

        if (completeImmediately)
        {
            ApprovalWorkflowStage[] notCompletedStages = context.Workflow.State.Stages
                .Where(s => !s.IsCompleted)
                .ToArray();

            foreach (var stage in notCompletedStages)
            {
                ApprovalWorkflowStageCompleter.Complete(stage, nextStageStatus);
            }

            return;
        }

        var stageIsCompleted = ApprovalWorkflowCompletedStageDetector.Detect(context.ActiveStage);

        if (stageIsCompleted)
        {
            ApprovalWorkflowStageCompleter.Complete(context.ActiveStage, nextStageStatus);

            context.Workflow.ApplicationEvents.Insert(0, StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent.Instance);
        }
    }

    private static void TryCompleteActiveGroup(
        ApprovalWorkflowGroup? activeGroup,
        Id<Employee> currentUserId,
        bool currentUserIsAdmin,
        ApprovalWorkflowAssignmentCompletionReason completionReason,
        string? completionComment)
    {
        if (activeGroup is not null)
        {
            ApprovalWorkflowGroupCompleter.Complete(activeGroup, currentUserId, completionReason, completionComment);

            return;
        }

        if (!currentUserIsAdmin)
        {
            throw new ApplicationException(
                $"""
                 User doesn't have an active assignments.
                 UserId: {currentUserId}
                 """);
        }
    }
}
