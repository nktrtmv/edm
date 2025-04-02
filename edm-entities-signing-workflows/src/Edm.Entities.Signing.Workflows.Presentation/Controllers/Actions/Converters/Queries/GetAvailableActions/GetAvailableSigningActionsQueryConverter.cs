using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailableActions;

internal static class GetAvailableSigningActionsQueryConverter
{
    internal static GetAvailableSigningActionsQueryInternal ToInternal(GetAvailableSigningActionsQuery query)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(query.Context);

        var result = new GetAvailableSigningActionsQueryInternal(context);

        return result;
    }
}
