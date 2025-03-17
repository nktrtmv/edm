using Edm.DocumentGenerator.Gateway.Core.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails.Contracts;

public sealed class GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBffResponse
{
    public required PersonBff[] DelegateFromPersons { get; init; }
}
