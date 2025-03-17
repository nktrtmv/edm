using Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts;

internal static class WorkflowCompletedEntitiesApprovalWorkflowsResultInternalConverter
{
    internal static ApprovalWorkflowDocumentUpdate ToDomain(WorkflowCompletedEntitiesApprovalWorkflowsResultInternal request, Id<User> currentUserId)
    {
        Id<DocumentApprovalWorkflow> workflowId = IdConverterFrom<DocumentApprovalWorkflow>.From(request.WorkflowId);

        DocumentApprovalStatus status = DocumentApprovalStatusInternalConverter.ToDomain(request.Status);

        var result = new ApprovalWorkflowDocumentUpdate(currentUserId, workflowId, status);

        return result;
    }
}
