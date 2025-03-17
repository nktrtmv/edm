using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;

internal static class ApprovalRouteInternalConverter
{
    internal static ApprovalWorkflowStage[] ToDomain(CreateWorkflowEntitiesApprovalWorkflowsRequestInternal request)
    {
        Id<Employee> currentUserId = IdConverterFrom<Employee>.From(request.CurrentUserId);

        ApprovalWorkflowStage[] result =
            request.ApprovalRoute.Stages.Select(s => ApprovalRouteStageInternalConverter.ToDomain(s, currentUserId)).ToArray();

        return result;
    }
}
