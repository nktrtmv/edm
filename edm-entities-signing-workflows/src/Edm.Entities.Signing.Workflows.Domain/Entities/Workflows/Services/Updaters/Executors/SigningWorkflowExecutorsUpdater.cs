using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Updaters.Executors;

public static class SigningWorkflowExecutorsUpdater
{
    public static void Update(SigningWorkflow workflow, Id<User> executorId)
    {
        bool isElectronic = workflow.Parameters.ElectronicDetails is not null;

        foreach (SigningStage stage in workflow.State.Stages)
        {
            if (StageExecutorShallBeUpdated(stage, isElectronic))
            {
                UpdateStageExecutor(stage, executorId);
            }
        }
    }

    private static bool StageExecutorShallBeUpdated(SigningStage stage, bool isElectronic)
    {
        bool isSignatory = isElectronic && stage.Party.Type == SigningPartyType.Self;

        if (isSignatory)
        {
            return false;
        }

        return true;
    }

    private static void UpdateStageExecutor(SigningStage stage, Id<User> executorId)
    {
        SigningParty updatedParty = SigningPartyFactory.CreateFrom(stage.Party.Type, stage.Party.CompanyId, executorId);

        stage.SetParty(updatedParty);
    }
}
