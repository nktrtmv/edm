using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetAvailableActions;

internal static class GetAvailableActionsSigningWorkflowDetailsQueryExternalConverter
{
    internal static GetSigningWorkflowAvailableActionsQuery ToDto(GetAvailableActionsSigningWorkflowDetailsQueryExternal query)
    {
        var result = new GetSigningWorkflowAvailableActionsQuery
        {
            WorkflowId = query.WorkflowId,
            CurrentUserId = query.CurrentUserId,
            IsCurrentUserAdmin = query.IsCurrentUserAdmin
        };

        return result;
    }
}
