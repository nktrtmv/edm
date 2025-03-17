using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;

internal static class DocumentApprovalWorkflowInternalConverter
{
    internal static DocumentApprovalWorkflowInternal FromDomain(DocumentApprovalWorkflow workflow)
    {
        Id<DocumentApprovalWorkflowInternal> id = IdConverterFrom<DocumentApprovalWorkflowInternal>.From(workflow.Id);

        DocumentApprovalWorkflowStatusInternal status = DocumentApprovalWorkflowStatusInternalConverter.FromDomain(workflow.Status);

        var result = new DocumentApprovalWorkflowInternal(id, status);

        return result;
    }
}
