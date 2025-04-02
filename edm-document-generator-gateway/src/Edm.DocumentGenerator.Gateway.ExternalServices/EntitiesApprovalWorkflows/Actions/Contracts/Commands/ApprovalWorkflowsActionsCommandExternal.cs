using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands;

public abstract record ApprovalWorkflowsActionsCommandExternal(EntitiesApprovalWorkflowActionContextExternal Context, bool CurrentUserIsOwner, bool CurrentUserIsAdmin);
