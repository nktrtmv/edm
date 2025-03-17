using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Electronics.Contractors;

internal static class AvailableContractorElectronicSigningActionsDetector
{
    private static readonly SigningActionType[] NoAvailableActions =
        Array.Empty<SigningActionType>();

    private static readonly SigningActionType[] SignedStageAvailableActions =
    {
        SigningActionType.PutIntoEffect
    };

    private static readonly SigningActionType[] RejectedAvailableActions =
    {
        SigningActionType.Cancel
    };

    private static readonly SigningActionType[] AdminRejectedAvailableActions =
    {
        SigningActionType.Cancel,
        SigningActionType.WithdrawByContractor
    };

    private static readonly SigningActionType[] ErrorAvailableActions =
    {
        SigningActionType.WithdrawByContractor
    };

    private static readonly SigningActionType[] RevokedAvailableActions =
    {
        SigningActionType.Cancel,
        SigningActionType.WithdrawByContractor
    };

    internal static SigningActionType[] Detect(SigningActionContext context)
    {
        SigningStage stage = context.Workflow.State.Stages.Single(s => s.Party.Type == SigningPartyType.Contractor);

        bool currentUserIsClerk = context.CurrentUserId == stage.Party.ExecutorId;

        bool currentUserIsAdmin = context.IsCurrentUserAdmin;

        if (!currentUserIsClerk && !currentUserIsAdmin)
        {
            return NoAvailableActions;
        }

        if (currentUserIsAdmin && stage.Status == SigningStageStatus.InProgress)
        {
            return ErrorAvailableActions;
        }

        if (currentUserIsAdmin && stage.Status == SigningStageStatus.Rejected)
        {
            return AdminRejectedAvailableActions;
        }

        SigningActionType[] result = DetectFromStatus(stage.Status);

        return result;
    }

    private static SigningActionType[] DetectFromStatus(SigningStageStatus status)
    {
        SigningActionType[] result = status switch
        {
            SigningStageStatus.NotStarted => NoAvailableActions,
            SigningStageStatus.InProgress => NoAvailableActions,
            SigningStageStatus.Completed => NoAvailableActions,
            SigningStageStatus.Signed => SignedStageAvailableActions,
            SigningStageStatus.Rejected => RejectedAvailableActions,
            SigningStageStatus.ReturnedToRework => NoAvailableActions,
            SigningStageStatus.Withdrawn => NoAvailableActions,
            SigningStageStatus.Cancelled => NoAvailableActions,
            SigningStageStatus.Error => ErrorAvailableActions,
            SigningStageStatus.Revocation => NoAvailableActions,
            SigningStageStatus.Revoked => RevokedAvailableActions,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
