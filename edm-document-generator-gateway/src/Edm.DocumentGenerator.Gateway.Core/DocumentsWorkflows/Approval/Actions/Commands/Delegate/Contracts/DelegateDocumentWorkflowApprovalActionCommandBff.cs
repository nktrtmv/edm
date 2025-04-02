using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Delegate.Contracts;

public sealed class DelegateDocumentWorkflowApprovalActionCommandBff
{
    public required DocumentWorkflowApprovalActionsContextBff Context { get; init; }
    public required string DelegateFromUserId { get; init; }
    public required string DelegateToUserId { get; init; }
    public required string Comment { get; init; }
    public bool CurrentUserIsOwner { get; init; }
    public required string DomainId { get; init; }
}
