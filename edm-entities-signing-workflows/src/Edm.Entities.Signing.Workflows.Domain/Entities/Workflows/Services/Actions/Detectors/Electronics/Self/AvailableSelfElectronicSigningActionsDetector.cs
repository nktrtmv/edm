using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Electronics.Self;

internal static class AvailableSelfElectronicSigningActionsDetector
{
    private static readonly SigningActionType[] NoAvailableActions =
        Array.Empty<SigningActionType>();

    private static readonly SigningActionType[] SignatoryAvailableActions =
    {
        SigningActionType.Sign,
        SigningActionType.WithdrawBySelf
    };

    private static readonly SigningActionType[] AdminOrClerkAvailableActions =
    {
        SigningActionType.WithdrawBySelf
    };

    internal static SigningActionType[] Detect(SigningActionContext context)
    {
        SigningStage stage = context.Workflow.State.Stages.Single(s => s.Party.Type == SigningPartyType.Self);

        bool currentUserIsSignatory = context.CurrentUserId == stage.Party.ExecutorId;

        if (currentUserIsSignatory)
        {
            return SignatoryAvailableActions;
        }

        bool currentUserIsAdmin = context.IsCurrentUserAdmin;

        bool currentUserIsClerk = CurrentUserIsClerk(context);

        if (currentUserIsAdmin || currentUserIsClerk)
        {
            return AdminOrClerkAvailableActions;
        }

        return NoAvailableActions;
    }

    private static bool CurrentUserIsClerk(SigningActionContext context)
    {
        SigningStage stage = context.Workflow.State.Stages.Single(s => s.Party.Type == SigningPartyType.Contractor);

        Id<User> clerkId = stage.Party.ExecutorId;

        bool result = context.CurrentUserId == clerkId;

        return result;
    }
}
