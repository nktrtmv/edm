using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Detectors;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators.ActionIsAvailable;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Actualizers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Delegate;

public static class DelegateApprovalWorkflowsActionsCommandProcessor
{
    public static void Delegate(ApprovalWorkflowActionContext context, Id<Employee> delegateFromUserId, Id<Employee> delegateToUserId, string comment)
    {
        ActionIsAvailableEntitiesApprovalWorkflowsValidator.Validate(context, ApprovalWorkflowActionKind.Delegate);

        var activeGroup =
            ActiveGroupApprovalWorkflowsDetector.GetRequired(context.ActiveGroups, delegateFromUserId);

        Id<Employee>[] previousActiveExecutors = ActiveApprovalWorkflowGroupsExecutorsExtractor.Extract(context.ActiveGroups);

        ApprovalWorkflowAssignment[] assignmentsToDelegate = activeGroup.Assignments
            .Where(a => a.ExecutorId == delegateFromUserId)
            .Where(a => a.IsActive)
            .ToArray();

        ApprovalWorkflowAssignment[] delegatedAssignments = assignmentsToDelegate
            .Select(a => Delegate(a, delegateToUserId, comment, context.CurrentUserId))
            .ToArray();

        ApprovalWorkflowAssignment[] assignments = activeGroup.Assignments
            .Concat(delegatedAssignments)
            .ToArray();

        ApprovalWorkflowAssignmentsActualizer.Actualize(assignments, context.Workflow, context.ActiveStage);

        activeGroup.SetAssignments(assignments);

        AddNotifications(previousActiveExecutors, context, delegateToUserId, comment);
    }

    private static ApprovalWorkflowAssignment Delegate(
        ApprovalWorkflowAssignment assignmentToDelegate,
        Id<Employee> delegateToUserId,
        string comment,
        Id<Employee> currentUserId)
    {
        var result = ApprovalWorkflowAssignmentFactory.CreateNew(delegateToUserId, assignmentToDelegate.Status, currentUserId, true);

        ApprovalWorkflowAssignmentStateUpdater.SetManuallyDelegated(assignmentToDelegate, result.Id, comment);

        return result;
    }

    private static void AddNotifications(Id<Employee>[] previousActiveExecutors, ApprovalWorkflowActionContext context, Id<Employee> delegateToUserId, string comment)
    {
        if (previousActiveExecutors.Contains(delegateToUserId))
        {
            return;
        }

        var participantsChangedEvent = new ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent();

        context.Workflow.ApplicationEvents.Add(participantsChangedEvent);
    }
}
