using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails.Contracts;

public sealed class GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBff
{
    public required DocumentWorkflowApprovalActionsContextBff Context { get; init; }
    public required string DomainId { get; init; }
}
