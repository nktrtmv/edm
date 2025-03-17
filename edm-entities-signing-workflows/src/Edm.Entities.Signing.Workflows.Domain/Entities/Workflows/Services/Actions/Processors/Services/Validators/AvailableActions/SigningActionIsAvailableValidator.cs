using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators.AvailableActions;

internal static class SigningActionIsAvailableValidator
{
    internal static void Validate(SigningActionContext context, SigningActionType action)
    {
        SigningActionType[] availableActions = AvailableSigningActionsDetector.Detect(context);

        if (!availableActions.Contains(action))
        {
            throw new ApplicationException($"Action (type: {action}) is not available in context ({context}).");
        }
    }
}
