using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts;

internal sealed record GetSigningWorkflowAvailableActionsQueryResponse
{
    internal required SigningWorkflowActionKindDto[] Actions { get; init; }
}
