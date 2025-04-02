using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval;

public sealed class ApprovalWorkflowDocumentUpdate
{
    public ApprovalWorkflowDocumentUpdate(Id<User> currentUserId, Id<DocumentApprovalWorkflow> workflowId, DocumentApprovalStatus status)
    {
        CurrentUserId = currentUserId;
        WorkflowId = workflowId;
        Status = status;
    }

    public Id<User> CurrentUserId { get; }
    public Id<DocumentApprovalWorkflow> WorkflowId { get; }
    public DocumentApprovalStatus Status { get; }
}
