using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailable;

internal static class GetAvailableEntitiesApprovalWorkflowsActionsQueryConverter
{
    internal static GetAvailableEntitiesApprovalWorkflowsActionsQueryInternal ToInternal(GetAvailableEntitiesApprovalWorkflowsActionsQuery query)
    {
        Id<ApprovalWorkflowInternal> workflowId = IdConverterFrom<ApprovalWorkflowInternal>.FromString(query.WorkflowId);

        Id<EmployeeInternal> currentUserId = IdConverterFrom<EmployeeInternal>.FromString(query.CurrentUserId);

        var result = new GetAvailableEntitiesApprovalWorkflowsActionsQueryInternal(workflowId, currentUserId, query.CurrentUserIsOwner, query.CurrentUserIsAdmin);

        return result;
    }
}
