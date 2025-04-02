using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Queries.GetAvailable;

internal static class GetAvailableEntitiesApprovalWorkflowsActionsQueryExternalConverter
{
    internal static GetAvailableEntitiesApprovalWorkflowsActionsQuery ToDto(GetAvailableEntitiesApprovalWorkflowsActionsQueryExternal query)
    {
        var result = new GetAvailableEntitiesApprovalWorkflowsActionsQuery
        {
            WorkflowId = query.WorkflowId,
            CurrentUserId = query.CurrentUserId,
            CurrentUserIsAdmin = query.CurrentUserIsAdmin
        };

        return result;
    }
}
