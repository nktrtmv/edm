using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateDocumentAuthor;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.UpdateDocumentAuthor;

internal static class UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestConverter
{
    internal static UpdateDocumentAuthorEntitiesApprovalWorkflowsRequest FromExternal(UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestExternal request)
    {
        DocumentApprovalWorkflow workflow = request.Document.ApprovalData.Workflows.Last();

        var workflowId = IdConverterTo.ToString(workflow.Id);

        var documentAuthorId = IdConverterTo.ToString(request.DocumentAuthorId);

        var result = new UpdateDocumentAuthorEntitiesApprovalWorkflowsRequest
        {
            WorkflowId = workflowId,
            DocumentAuthorId = documentAuthorId
        };

        return result;
    }
}
