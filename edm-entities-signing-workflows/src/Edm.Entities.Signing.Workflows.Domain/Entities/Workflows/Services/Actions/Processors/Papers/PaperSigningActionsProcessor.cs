using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Papers.Validators;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Papers;

internal static class PaperSigningActionsProcessor
{
    internal static void Process(SigningActionContext context, SigningActionType action, SigningStageStatus status, string? completionComment = null)
    {
        PaperSigningActionsValidator.Validate(context.Workflow, action);

        SigningStage activeStage = GetActiveStage(context.Workflow);

        SigningStageStateUpdater.UpdateState(activeStage, status, completionComment, SigningStageStatus.InProgress);

        SigningWorkflowStatusUpdater.Advance(context.Workflow, activeStage.IsAborted);
    }

    private static SigningStage GetActiveStage(SigningWorkflow workflow)
    {
        SigningStage? result = workflow.State.Stages.LastOrDefault(s => s.Status == SigningStageStatus.InProgress);

        if (result is null)
        {
            throw new InvalidOperationException($"Active stage (status: {SigningStageStatus.InProgress}) for workflow ({workflow}) is not found.");
        }

        return result;
    }
}
