using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Chief;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Chief;

internal static class ChiefApprovalRouteGroupDtoConverter
{
    internal static ApprovalGroupInternal ToInternal(string name)
    {
        var result = new ChiefApprovalGroupInternal(name);

        return result;
    }
}
