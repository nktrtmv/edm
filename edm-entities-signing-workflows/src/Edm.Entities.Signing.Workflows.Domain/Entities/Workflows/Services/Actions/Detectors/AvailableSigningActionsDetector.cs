using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Electronics;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Papers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors;

public static class AvailableSigningActionsDetector
{
    private static readonly SigningActionType[] NoAvailableActionsActions =
        Array.Empty<SigningActionType>();

    public static SigningActionType[] Detect(SigningActionContext context)
    {
        if (context.Workflow.State.Status == SigningStatus.Completed)
        {
            return NoAvailableActionsActions;
        }

        bool isPaperSigning = context.Workflow.Parameters.ElectronicDetails is null;

        SigningActionType[] result = isPaperSigning
            ? AvailablePaperSigningActionsDetector.Detect(context)
            : AvailableElectronicSigningActionsDetector.Detect(context);

        return result;
    }
}
