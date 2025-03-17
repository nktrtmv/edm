using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetAvailableActions;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details;

internal sealed class SigningWorkflowsDetailsClient : ISigningWorkflowsDetailsClient
{
    public SigningWorkflowsDetailsClient(
        SigningDetailsService.SigningDetailsServiceClient details,
        GetSigningWorkflowDocumentWorkflowsService workflows,
        GetSigningWorkflowAvailableActionsService availableActions)
    {
        Details = details;
        Workflows = workflows;
        AvailableActions = availableActions;
    }

    private SigningDetailsService.SigningDetailsServiceClient Details { get; }
    private GetSigningWorkflowDocumentWorkflowsService Workflows { get; }
    private GetSigningWorkflowAvailableActionsService AvailableActions { get; }

    async Task<GetAvailableActionsSigningWorkflowDetailsQueryResponseExternal> ISigningWorkflowsDetailsClient.GetAvailableActions(
        GetAvailableActionsSigningWorkflowDetailsQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request =
            GetAvailableActionsSigningWorkflowDetailsQueryExternalConverter.ToDto(query);

        var response =
            await AvailableActions.Get(request, cancellationToken);

        var result =
            GetAvailableActionsSigningWorkflowDetailsQueryResponseExternalConverter.FromDto(response);

        return result;
    }

    async Task<GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternal> ISigningWorkflowsDetailsClient.GetElectronicDetails(
        GetElectronicDetailsSigningWorkflowDetailsQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request =
            GetElectronicDetailsSigningWorkflowDetailsQueryExternalConverter.ToDto(query);

        var response =
            await Details.GetElectronicAsync(request, cancellationToken: cancellationToken);

        var result =
            GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternalConverter.FromDto(response);

        return result;
    }

    async Task<GetWorkflowsSigningWorkflowDetailsQueryResponseExternal> ISigningWorkflowsDetailsClient.GetWorkflows(
        GetWorkflowsSigningWorkflowDetailsQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request =
            GetWorkflowsSigningWorkflowDetailsQueryExternalConverter.ToDto(query);

        var response =
            await Workflows.Get(request, cancellationToken);

        var result =
            GetWorkflowsSigningWorkflowDetailsQueryResponseExternalConverter.FromDto(response);

        return result;
    }
}
