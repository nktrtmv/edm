using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails.Contracts.Contracts.Groups;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails.Contracts;

public sealed class GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponse
{
    public required GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponseGroup[] Groups { get; init; }
}
