using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Approval;

internal static class DocumentApprovalWorkflowsChecker
{
    internal static bool IsAlreadyProcessed(Document document, Id<DocumentApprovalWorkflow> workflowId)
    {
        if (document.Status.Type != DocumentStatusType.Approval)
        {
            return true;
        }

        DocumentApprovalWorkflow currentWorkflow = document.ApprovalData.Workflows.Last();

        if (currentWorkflow.Id != workflowId)
        {
            return true;
        }

        if (currentWorkflow.Status != DocumentApprovalWorkflowStatus.InProgress)
        {
            return true;
        }

        return false;
    }
}
