using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails.Contracts;

public sealed class GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBff
{
    public required DocumentWorkflowApprovalActionsContextBff Context { get; init; }
    public required string DomainId { get; init; }
}
