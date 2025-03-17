using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;

public sealed class DocumentApprovalWorkflowInternal
{
    internal DocumentApprovalWorkflowInternal(Id<DocumentApprovalWorkflowInternal> id, DocumentApprovalWorkflowStatusInternal status)
    {
        Id = id;
        Status = status;
    }

    public Id<DocumentApprovalWorkflowInternal> Id { get; }
    public DocumentApprovalWorkflowStatusInternal Status { get; }
}
