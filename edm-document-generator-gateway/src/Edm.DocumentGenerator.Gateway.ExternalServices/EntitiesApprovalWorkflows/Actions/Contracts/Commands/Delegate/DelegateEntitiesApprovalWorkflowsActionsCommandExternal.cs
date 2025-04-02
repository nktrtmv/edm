using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Delegate;

public sealed record DelegateEntitiesApprovalWorkflowsActionsCommandExternal(
    EntitiesApprovalWorkflowActionContextExternal Context,
    string DelegateFromUserId,
    string DelegateToUserId,
    string Comment,
    bool CurrentUserIsOwner,
    bool CurrentUserIsAdmin)
    : ApprovalWorkflowsActionsCommandExternal(Context, CurrentUserIsOwner, CurrentUserIsAdmin);
