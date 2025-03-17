using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailableActions.Contracts.ActionsTypes;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailableActions;

internal static class GetAvailableSigningActionsQueryResponseConverter
{
    internal static GetAvailableSigningActionsQueryResponse FromInternal(GetAvailableSigningActionsQueryInternalResponse response)
    {
        SigningActionTypeDto[] actions = response.Actions.Select(SigningActionTypeDtoConverter.FromInternal).ToArray();

        var result = new GetAvailableSigningActionsQueryResponse
        {
            Actions = { actions }
        };

        return result;
    }
}
