using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Queries.GetAvailable.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Queries.GetAvailable;

internal static class GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternalConverter
{
    internal static GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternal FromDto(GetAvailableEntitiesApprovalWorkflowsActionsQueryResponse response)
    {
        var actions =
            response.Actions.Select(EntitiesApprovalWorkflowActionKindExternalConverter.FromDto).ToArray();

        var result = new GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternal(actions);

        return result;
    }
}
