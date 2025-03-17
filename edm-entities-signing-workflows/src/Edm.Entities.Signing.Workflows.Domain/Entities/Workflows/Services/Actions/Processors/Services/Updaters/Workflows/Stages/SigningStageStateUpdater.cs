using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows.Stages;

internal static class SigningStageStateUpdater
{
    internal static void UpdateState(SigningStage stage, SigningStageStatus status, string? completionComment, params SigningStageStatus[] validStatuses)
    {
        if (!validStatuses.Contains(stage.Status))
        {
            throw new ApplicationException($"Invalid stage ({stage}) status change requested (to: {status}).");
        }

        SigningStageState state = SigningStageStateFactory.CreateFrom(status);

        stage.SetState(state, completionComment);
    }
}
