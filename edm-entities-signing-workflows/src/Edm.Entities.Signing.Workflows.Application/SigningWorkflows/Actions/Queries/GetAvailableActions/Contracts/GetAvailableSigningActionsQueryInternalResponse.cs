using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts.Contracts.ActionsTypes;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts;

public sealed class GetAvailableSigningActionsQueryInternalResponse
{
    internal GetAvailableSigningActionsQueryInternalResponse(SigningActionTypeInternal[] actions)
    {
        Actions = actions;
    }

    public SigningActionTypeInternal[] Actions { get; }
}
