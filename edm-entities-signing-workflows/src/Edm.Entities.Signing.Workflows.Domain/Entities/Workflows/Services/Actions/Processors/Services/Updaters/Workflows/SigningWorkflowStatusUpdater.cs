using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;

using JetBrains.Annotations;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows;

internal static class SigningWorkflowStatusUpdater
{
    internal static void Advance(SigningWorkflow workflow, bool isFinished)
    {
        if (isFinished)
        {
            CompleteUncompletedStages(workflow);

            UpdateStatus(workflow, SigningStatus.Completed, SigningStatus.InProgress);

            return;
        }

        SigningStage? nextStage = workflow.State.Stages.FirstOrDefault(s => s.Status is SigningStageStatus.NotStarted);

        if (nextStage is null)
        {
            UpdateStatus(workflow, SigningStatus.Completed, SigningStatus.InProgress);

            return;
        }

        SigningStageStateUpdater.UpdateState(nextStage, SigningStageStatus.InProgress, null, SigningStageStatus.NotStarted);

        UpdateStatus(workflow, SigningStatus.InProgress, SigningStatus.NotStarted, SigningStatus.InProgress);
    }

    [AssertionMethod]
    private static void UpdateStatus(SigningWorkflow workflow, SigningStatus status, params SigningStatus[] validStatuses)
    {
        if (!validStatuses.Contains(workflow.State.Status))
        {
            throw new InvalidOperationException($"Invalid workflow ({workflow}) status change requested (to: {status}).");
        }

        workflow.State.SetStatus(status);
    }

    private static void CompleteUncompletedStages(SigningWorkflow workflow)
    {
        SigningStage[] stages = workflow.State.Stages.Where(s => s.IsInProgress).ToArray();

        foreach (SigningStage stage in stages)
        {
            SigningStageStateUpdater.UpdateState(stage, SigningStageStatus.Completed, null, stage.Status);
        }
    }
}
