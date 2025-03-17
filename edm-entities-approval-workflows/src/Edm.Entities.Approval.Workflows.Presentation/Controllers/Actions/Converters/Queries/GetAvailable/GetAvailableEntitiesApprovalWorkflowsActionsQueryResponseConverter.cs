using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailable.Kinds;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailable;

internal static class GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseConverter
{
    internal static GetAvailableEntitiesApprovalWorkflowsActionsQueryResponse FromInternal(GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse response)
    {
        EntitiesApprovalWorkflowsActionKindDto[] actions =
            response.Actions.Select(EntitiesApprovalWorkflowsActionKindDtoConverter.FromInternal).ToArray();

        var result = new GetAvailableEntitiesApprovalWorkflowsActionsQueryResponse
        {
            Actions = { actions }
        };

        return result;
    }
}
