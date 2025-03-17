using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes;

internal static class ApprovalRouteDtoConverter
{
    internal static ApprovalRouteInternal ToInternal(ApprovalRouteDto route)
    {
        ApprovalRouteStageInternal[] stages =
            route.Stages.Select(ApprovalRouteStageDtoConverter.ToInternal).ToArray();

        var result = new ApprovalRouteInternal(stages);

        return result;
    }
}
