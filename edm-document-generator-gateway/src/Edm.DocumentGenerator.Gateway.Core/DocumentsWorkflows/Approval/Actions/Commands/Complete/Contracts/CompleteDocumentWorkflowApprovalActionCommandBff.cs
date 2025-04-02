using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts.CompletionReasons;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts;

public sealed class CompleteDocumentWorkflowApprovalActionCommandBff
{
    public required DocumentWorkflowApprovalActionsContextBff Context { get; init; }
    public required DocumentWorkflowApprovalActionCompletionReasonBff CompletionReason { get; init; }
    public string? CompletionComment { get; init; }
    public bool CurrentUserIsOwner { get; init; }
    public required string DomainId { get; init; }
}
