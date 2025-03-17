using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Papers;

internal static class AvailablePaperSigningActionsDetector
{
    private static readonly SigningActionType[] NoAvailableActionsActions =
        Array.Empty<SigningActionType>();

    private static readonly SigningActionType[] SelfAvailableActions =
    {
        SigningActionType.SendToContractor,
        SigningActionType.Cancel,
        SigningActionType.ReturnToRework,
        SigningActionType.WithdrawBySelf
    };

    private static readonly SigningActionType[] ContractorAvailableActions =
    {
        SigningActionType.PutIntoEffect,
        SigningActionType.WithdrawByContractor
    };

    internal static SigningActionType[] Detect(SigningActionContext context)
    {
        SigningStage? activeStage = context.Workflow.State.Stages.SingleOrDefault(s => s.Status == SigningStageStatus.InProgress);

        if (activeStage is null)
        {
            return NoAvailableActionsActions;
        }

        bool isAuthored = context.CurrentUserId == activeStage.Party.ExecutorId || context.IsCurrentUserAdmin;

        if (!isAuthored)
        {
            return NoAvailableActionsActions;
        }

        bool isSelfStage = activeStage.Party.Type == SigningPartyType.Self;

        SigningActionType[] result = isSelfStage
            ? SelfAvailableActions
            : ContractorAvailableActions;

        return result;
    }
}
