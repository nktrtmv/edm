using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.AddParticipant;

public sealed record AddParticipantEntitiesApprovalWorkflowsActionsCommandExternal(
    EntitiesApprovalWorkflowActionContextExternal Context,
    string NewParticipantId,
    string? GroupId,
    string? GroupName,
    string Comment,
    bool CurrentUserIsOwner,
    bool CurrentUserIsAdmin)
    : ApprovalWorkflowsActionsCommandExternal(Context, CurrentUserIsOwner, CurrentUserIsAdmin);
