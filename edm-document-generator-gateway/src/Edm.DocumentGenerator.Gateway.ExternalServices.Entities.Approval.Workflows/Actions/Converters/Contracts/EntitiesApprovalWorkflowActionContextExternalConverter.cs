using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Contracts;

internal static class EntitiesApprovalWorkflowActionContextExternalConverter
{
    internal static EntitiesApprovalWorkflowsActionContextDto ToDto(
        EntitiesApprovalWorkflowActionContextExternal context,
        bool currentUserIsOwner,
        bool currentUserIsAdmin)
    {
        var result = new EntitiesApprovalWorkflowsActionContextDto
        {
            WorkflowId = context.WorkflowId,
            StageId = context.StageId,
            CurrentUserId = context.CurrentUserId,
            CurrentUserIsOwner = currentUserIsOwner,
            CurrentUserIsAdmin = currentUserIsAdmin
        };

        return result;
    }
}
