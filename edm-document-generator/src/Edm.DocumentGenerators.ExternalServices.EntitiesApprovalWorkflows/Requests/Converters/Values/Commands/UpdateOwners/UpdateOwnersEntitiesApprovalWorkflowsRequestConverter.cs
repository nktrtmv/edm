using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateOwners;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.UpdateOwners;

internal static class UpdateOwnersEntitiesApprovalWorkflowsRequestConverter
{
    internal static UpdateOwnersEntitiesApprovalWorkflowsRequest FromExternal(UpdateOwnersEntitiesApprovalWorkflowsRequestExternal request)
    {
        DocumentApprovalWorkflow workflow = request.Document.ApprovalData.Workflows.Last();

        var workflowId = IdConverterTo.ToString(workflow.Id);

        var ownerId = IdConverterTo.ToString(request.OwnerId);

        var result = new UpdateOwnersEntitiesApprovalWorkflowsRequest
        {
            WorkflowId = workflowId,
            OwnersIds = { ownerId }
        };

        return result;
    }
}
