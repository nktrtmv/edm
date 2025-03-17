using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.AddParticipant.Contracts;

public sealed class AddParticipantDocumentWorkflowApprovalActionCommandBff
{
    public required DocumentWorkflowApprovalActionsContextBff Context { get; init; }
    public required string UserId { get; init; }
    public string? GroupId { get; init; }
    public string? GroupName { get; init; }
    public required string Comment { get; init; }
    public bool CurrentUserIsOwner { get; init; }
    public required string DomainId { get; init; }
}
