using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable;

public sealed class GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternal
{
    public GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternal(EntitiesApprovalWorkflowActionKindExternal[] actions)
    {
        Actions = actions;
    }

    public EntitiesApprovalWorkflowActionKindExternal[] Actions { get; }
}
