using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted.Factories.LastFinishedStageStatuses;

internal static class LastFinishedStageStatusDetector
{
    internal static SigningStageStatus DetectFrom(SigningWorkflow workflow)
    {
        if (workflow.State.Status != SigningStatus.Completed)
        {
            throw new ApplicationException($"Signing workflow {workflow} is not finished.");
        }

        SigningStage? lastFinishedStage = workflow.State.Stages.LastOrDefault(IsStageFinished);

        if (lastFinishedStage is null)
        {
            throw new ApplicationException($"Failed to find last finished stage for workflow ({workflow}).");
        }

        SigningStageStatus result = lastFinishedStage.Status;

        return result;
    }

    private static bool IsStageFinished(SigningStage stage)
    {
        if (stage.IsAborted)
        {
            return true;
        }

        if (stage is { Status: SigningStageStatus.Signed, Party.Type: SigningPartyType.Contractor })
        {
            return true;
        }

        return false;
    }
}
