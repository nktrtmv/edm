using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators.ActionIsAvailable;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Actualizers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Custom;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.AddParticipant;

public static class AddParticipantApprovalWorkflowsActionsCommandProcessor
{
    public static void Add(
        ApprovalWorkflowActionContext context,
        Id<Employee> newParticipantId,
        Id<ApprovalWorkflowGroup>? groupId,
        string? groupName)
    {
        ActionIsAvailableEntitiesApprovalWorkflowsValidator.Validate(context, ApprovalWorkflowActionKind.AddParticipant);

        var group =
            TryGetExistingGroup(context, groupId) ??
            TryCreateCustomGroup(context, groupName);

        if (group is null)
        {
            throw new ApplicationException(
                $"""
                 Participants can be added only to active group.
                 NewParticipantId: {newParticipantId}
                 Context: {context}
                 """);
        }

        Id<Employee>[] previousActiveExecutors = ActiveApprovalWorkflowGroupsExecutorsExtractor.Extract(context.ActiveGroups);

        var assignment = ApprovalWorkflowAssignmentFactory.CreateNew(
            newParticipantId,
            ApprovalWorkflowAssignmentStatus.NotStarted,
            context.CurrentUserId,
            true);

        ApprovalWorkflowAssignment[] assignments = group.Assignments
            .Append(assignment)
            .ToArray();

        ResetInProgressAssignmentsDueMasterWorkflow(assignments);

        group.SetAssignments(assignments);

        ApprovalWorkflowAssignmentsActualizer.Actualize(assignments, context.Workflow, context.ActiveStage);

        AddNotifications(previousActiveExecutors, context, assignment);
    }

    private static ApprovalWorkflowGroup? TryGetExistingGroup(ApprovalWorkflowActionContext context, Id<ApprovalWorkflowGroup>? groupId)
    {
        if (groupId is null)
        {
            return null;
        }

        var result = context.ActiveGroups.SingleOrDefault(g => g.Id == groupId);

        return result;
    }

    private static ApprovalWorkflowGroup? TryCreateCustomGroup(ApprovalWorkflowActionContext context, string? groupName)
    {
        if (string.IsNullOrWhiteSpace(groupName))
        {
            return null;
        }

        var status = context.ActiveStage.Type is ApprovalWorkflowStageType.Sequential
            ? ApprovalWorkflowGroupStatus.NotStarted
            : ApprovalWorkflowGroupStatus.InProgress;

        var result = ApprovalWorkflowGroupFactory.CreateFrom(
            groupName,
            ApprovalWorkflowCustomApprovalGroup.Instance,
            status);

        ApprovalWorkflowGroup[] groups = context.ActiveStage.Groups
            .Append(result)
            .ToArray();

        context.ActiveStage.SetGroups(groups);

        return result;
    }

    private static void ResetInProgressAssignmentsDueMasterWorkflow(ApprovalWorkflowAssignment[] assignments)
    {
        var inProgressAssignments = assignments
            .Where(a => a.Status == ApprovalWorkflowAssignmentStatus.InProgress)
            .ToArray();

        foreach (var inProgressAssignment in inProgressAssignments)
        {
            ApprovalWorkflowAssignmentStateUpdater.SetNotStarted(inProgressAssignment);
        }
    }

    private static void AddNotifications(
        Id<Employee>[] previousActiveExecutors,
        ApprovalWorkflowActionContext context,
        ApprovalWorkflowAssignment assignment)
    {
        if (previousActiveExecutors.Contains(assignment.ExecutorId))
        {
            return;
        }

        var participantsChangedEvent = new ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent();

        context.Workflow.ApplicationEvents.Add(participantsChangedEvent);
    }
}
