using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Electronics.Contractors;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Electronics.Self;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Electronics;

internal static class AvailableElectronicSigningActionsDetector
{
    internal static SigningActionType[] Detect(SigningActionContext context)
    {
        bool currentStageIsSelf = CurrentStageIsSelf(context);

        SigningActionType[] result = currentStageIsSelf
            ? AvailableSelfElectronicSigningActionsDetector.Detect(context)
            : AvailableContractorElectronicSigningActionsDetector.Detect(context);

        return result;
    }

    private static bool CurrentStageIsSelf(SigningActionContext context)
    {
        SigningStage selfStage = context.Workflow.State.Stages.Single(s => s.Party.Type == SigningPartyType.Self);

        bool result = selfStage.Status == SigningStageStatus.InProgress;

        return result;
    }
}
