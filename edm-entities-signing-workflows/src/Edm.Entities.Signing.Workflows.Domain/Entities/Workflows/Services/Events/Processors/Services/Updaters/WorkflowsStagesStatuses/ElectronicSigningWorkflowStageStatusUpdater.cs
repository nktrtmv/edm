using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Updaters.WorkflowsStagesStatuses;

internal static class ElectronicSigningWorkflowStageStatusUpdater
{
    internal static void Update(SigningStage stage, SigningStageStatus status)
    {
        SigningStageState state = SigningStageStateFactory.CreateFrom(status);

        stage.SetState(state);
    }
}
