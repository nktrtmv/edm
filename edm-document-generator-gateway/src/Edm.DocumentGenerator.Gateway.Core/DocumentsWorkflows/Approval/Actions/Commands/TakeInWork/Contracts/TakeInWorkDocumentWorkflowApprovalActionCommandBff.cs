using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.TakeInWork.Contracts;

public sealed class TakeInWorkDocumentWorkflowApprovalActionCommandBff
{
    public required DocumentWorkflowApprovalActionsContextBff Context { get; init; }
    public bool CurrentUserIsOwner { get; init; }
    public required string DomainId { get; init; }
}
