using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts.Factories;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts;

internal static class GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalConverter
{
    internal static ApprovalWorkflowActionContext ToDomain(
        GetAvailableEntitiesApprovalWorkflowsActionsQueryInternal context,
        ApprovalWorkflow workflow)
    {
        var currentUserId = IdConverterFrom<Employee>.From(context.CurrentUserId);

        var result =
            ApprovalWorkflowActionContextFactory.CreateFrom(workflow, currentUserId, context.CurrentUserIsOwner, context.CurrentUserIsAdmin);

        return result;
    }
}
