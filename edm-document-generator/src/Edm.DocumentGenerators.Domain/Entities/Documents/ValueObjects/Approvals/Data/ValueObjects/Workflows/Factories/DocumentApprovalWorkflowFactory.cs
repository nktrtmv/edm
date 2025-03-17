using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.Factories;

public static class DocumentApprovalWorkflowFactory
{
    public static DocumentApprovalWorkflow CreateNew()
    {
        var id = Id<DocumentApprovalWorkflow>.CreateNew();

        var result = new DocumentApprovalWorkflow(id, DocumentApprovalWorkflowStatus.InProgress);

        return result;
    }

    public static DocumentApprovalWorkflow FromDb(
        Id<DocumentApprovalWorkflow> id,
        DocumentApprovalWorkflowStatus status)
    {
        var result = new DocumentApprovalWorkflow(id, status);

        return result;
    }
}
