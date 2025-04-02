using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;

public sealed class DocumentApprovalWorkflow
{
    internal DocumentApprovalWorkflow(
        Id<DocumentApprovalWorkflow> id,
        DocumentApprovalWorkflowStatus status)
    {
        Id = id;
        Status = status;
    }

    public Id<DocumentApprovalWorkflow> Id { get; }
    public DocumentApprovalWorkflowStatus Status { get; private set; }

    public void SetStatus(DocumentApprovalWorkflowStatus status)
    {
        Status = status;
    }
}
