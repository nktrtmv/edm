using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Actualizers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators;

internal sealed class ApprovalWorkflowStageActivator
{
    public ApprovalWorkflowStageActivator(ApprovalWorkflowAssignmentsManager assignments)
    {
        Assignments = assignments;
    }

    private ApprovalWorkflowAssignmentsManager Assignments { get; }

    internal async Task TryActivate(ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        if (workflow.IsCompleted)
        {
            return;
        }

        var activeStage = await TryStart(workflow, cancellationToken);

        ApprovalWorkflowGroup[] groupsToStart = GetGroupsToStart(activeStage);

        if (!workflow.Parameters.Options.AutoDelegatingIsDisabled)
        {
            UtcDateTime<ApprovalWorkflowState> actualizedDate = UtcDateTime<ApprovalWorkflowState>.Now;

            Assignments.ActualizeAssignments(workflow.Parameters.Entity.DomainId, groupsToStart, actualizedDate, cancellationToken);

            workflow.State.SetActualizedDate(actualizedDate);
        }

        StartGroups(groupsToStart, workflow, activeStage);
    }

    private async Task<ApprovalWorkflowStage> TryStart(ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        var result = workflow.State.Stages
            .First(s => !s.IsCompleted);

        if (result.Status != ApprovalWorkflowStageStatus.NotStarted)
        {
            return result;
        }

        result.SetStatus(ApprovalWorkflowStageStatus.InProgress);

        UtcDateTime<ApprovalWorkflowStage> startedDate = UtcDateTime<ApprovalWorkflowStage>.Now;

        result.SetStartedDate(startedDate);

        await Assignments.CreateRootAssignments(result.Groups, workflow, cancellationToken);

        return result;
    }

    private static void StartGroups(ApprovalWorkflowGroup[] groupsToStart, ApprovalWorkflow workflow, ApprovalWorkflowStage activeStage)
    {
        foreach (var groupToStart in groupsToStart)
        {
            ApprovalWorkflowAssignmentsActualizer.Actualize(groupToStart.Assignments, workflow, activeStage);

            groupToStart.SetStatus(ApprovalWorkflowGroupStatus.InProgress);
        }
    }

    private static ApprovalWorkflowGroup[] GetGroupsToStart(ApprovalWorkflowStage stage)
    {
        var result = stage.Groups
            .Where(g => g.Status == ApprovalWorkflowGroupStatus.NotStarted)
            .ToArray();

        if (stage.Type is ApprovalWorkflowStageType.Sequential)
        {
            var group = result.First();

            result = new[] { group };
        }

        return result;
    }
}
