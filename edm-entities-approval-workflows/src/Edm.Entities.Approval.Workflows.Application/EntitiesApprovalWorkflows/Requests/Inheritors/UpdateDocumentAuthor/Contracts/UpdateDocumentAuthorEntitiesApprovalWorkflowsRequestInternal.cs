using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateDocumentAuthor.Contracts;

public sealed class UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestInternal(
    Id<ApprovalWorkflowInternal> workflowId,
    Id<EmployeeInternal> documentAuthorId)
    : EntitiesApprovalWorkflowsRequestInternal(workflowId)
{
    internal Id<EmployeeInternal> DocumentAuthorId { get; } = documentAuthorId;
}
