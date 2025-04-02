using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.TakeInWork;

public sealed record TakeInWorkEntitiesApprovalWorkflowsActionsCommandExternal(
    EntitiesApprovalWorkflowActionContextExternal Context,
    bool CurrentUserIsOwner,
    bool CurrentUserIsAdmin)
    : ApprovalWorkflowsActionsCommandExternal(Context, CurrentUserIsOwner, CurrentUserIsAdmin);
