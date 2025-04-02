using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete.CompletionReason;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete;

public sealed record CompleteEntitiesApprovalWorkflowsActionsCommandExternal(
    EntitiesApprovalWorkflowActionContextExternal Context,
    ReductionWorkflowActionCompletionReasonExternal CompletionReason,
    string? CompletionComment,
    bool CurrentUserIsOwner,
    bool CurrentUserIsAdmin)
    : ApprovalWorkflowsActionsCommandExternal(Context, CurrentUserIsOwner, CurrentUserIsAdmin);
