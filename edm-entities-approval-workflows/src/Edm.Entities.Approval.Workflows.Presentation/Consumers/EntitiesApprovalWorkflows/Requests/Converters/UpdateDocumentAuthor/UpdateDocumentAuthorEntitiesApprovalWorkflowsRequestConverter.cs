using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateDocumentAuthor.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.UpdateDocumentAuthor;

internal static class UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestConverter
{
    internal static UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestInternal ToInternal(UpdateDocumentAuthorEntitiesApprovalWorkflowsRequest request)
    {
        var workflowId = IdConverterFrom<ApprovalWorkflowInternal>.FromString(request.WorkflowId);

        Id<EmployeeInternal> documentAuthorId = IdConverterFrom<EmployeeInternal>.FromString(request.DocumentAuthorId);

        var result = new UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestInternal(workflowId, documentAuthorId);

        return result;
    }
}
