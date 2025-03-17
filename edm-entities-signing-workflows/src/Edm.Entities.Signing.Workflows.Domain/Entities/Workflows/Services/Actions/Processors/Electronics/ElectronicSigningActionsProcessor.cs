using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Electronics;

internal static class ElectronicSigningActionsProcessor
{
    internal static void Process(SigningActionContext context, SigningStageStatus status, string? completionComment = null)
    {
        bool completeWorkflow = UpdateActiveStage(context, status, completionComment);

        SigningWorkflowStatusUpdater.Advance(context.Workflow, completeWorkflow);
    }

    private static bool UpdateActiveStage(SigningActionContext context, SigningStageStatus status, string? completionComment = null)
    {
        SigningStage? activeStage = context.Workflow.State.Stages.FirstOrDefault(s => s.IsActive);

        if (activeStage is null)
        {
            return true;
        }

        SigningStageStateUpdater.UpdateState(activeStage, status, completionComment, activeStage.Status);

        bool result = activeStage.IsAborted;

        return result;
    }
}
