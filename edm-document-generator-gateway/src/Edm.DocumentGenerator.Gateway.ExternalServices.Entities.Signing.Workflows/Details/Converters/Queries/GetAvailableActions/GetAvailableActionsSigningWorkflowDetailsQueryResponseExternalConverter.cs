using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetAvailableActions.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetAvailableActions;

internal static class GetAvailableActionsSigningWorkflowDetailsQueryResponseExternalConverter
{
    internal static GetAvailableActionsSigningWorkflowDetailsQueryResponseExternal FromDto(GetSigningWorkflowAvailableActionsQueryResponse response)
    {
        var actions =
            response.Actions.Select(SigningActionKindExternalConverter.FromDto).ToArray();

        var result = new GetAvailableActionsSigningWorkflowDetailsQueryResponseExternal(actions);

        return result;
    }
}
