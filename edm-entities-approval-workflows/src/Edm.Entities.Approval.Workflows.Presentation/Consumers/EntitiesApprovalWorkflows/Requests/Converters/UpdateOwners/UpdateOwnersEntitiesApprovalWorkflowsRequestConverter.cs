using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateOwners.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.UpdateOwners;

internal static class UpdateOwnersEntitiesApprovalWorkflowsRequestConverter
{
    internal static UpdateOwnersEntitiesApprovalWorkflowsRequestInternal ToInternal(UpdateOwnersEntitiesApprovalWorkflowsRequest request)
    {
        var workflowId = IdConverterFrom<ApprovalWorkflowInternal>.FromString(request.WorkflowId);

        Id<EmployeeInternal> ownerId = request.OwnersIds.Select(IdConverterFrom<EmployeeInternal>.FromString).Single();

        var result = new UpdateOwnersEntitiesApprovalWorkflowsRequestInternal(workflowId, ownerId);

        return result;
    }
}
