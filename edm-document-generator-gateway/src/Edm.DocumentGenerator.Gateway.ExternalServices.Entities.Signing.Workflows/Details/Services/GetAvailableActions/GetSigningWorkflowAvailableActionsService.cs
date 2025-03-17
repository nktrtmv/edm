using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions;

internal sealed class GetSigningWorkflowAvailableActionsService
{
    public GetSigningWorkflowAvailableActionsService(SigningActionsService.SigningActionsServiceClient actions)
    {
        Actions = actions;
    }

    private SigningActionsService.SigningActionsServiceClient Actions { get; }

    internal async Task<GetSigningWorkflowAvailableActionsQueryResponse> Get(GetSigningWorkflowAvailableActionsQuery query, CancellationToken cancellationToken)
    {
        var context = new SigningActionContextDto
        {
            WorkflowId = query.WorkflowId,
            CurrentUserId = query.CurrentUserId,
            IsCurrentUserAdmin = query.IsCurrentUserAdmin
        };

        var request = new GetAvailableSigningActionsQuery
        {
            Context = context
        };

        var response = await Actions.GetAvailableActionsAsync(request, cancellationToken: cancellationToken);

        var actions = response.Actions.Select(SigningWorkflowActionKindDtoConverter.FromDto).ToArray();

        var result = new GetSigningWorkflowAvailableActionsQueryResponse
        {
            Actions = actions
        };

        return result;
    }
}
