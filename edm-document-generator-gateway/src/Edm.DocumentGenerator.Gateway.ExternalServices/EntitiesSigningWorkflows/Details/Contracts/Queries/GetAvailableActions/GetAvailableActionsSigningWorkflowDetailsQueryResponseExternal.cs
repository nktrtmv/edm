using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions;

public sealed class GetAvailableActionsSigningWorkflowDetailsQueryResponseExternal
{
    public GetAvailableActionsSigningWorkflowDetailsQueryResponseExternal(SigningWorkflowActionKindExternal[] actions)
    {
        Actions = actions;
    }

    public SigningWorkflowActionKindExternal[] Actions { get; }
}
