using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details;

public interface ISigningWorkflowsDetailsClient
{
    Task<GetAvailableActionsSigningWorkflowDetailsQueryResponseExternal> GetAvailableActions(
        GetAvailableActionsSigningWorkflowDetailsQueryExternal query,
        CancellationToken cancellationToken);

    Task<GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternal> GetElectronicDetails(
        GetElectronicDetailsSigningWorkflowDetailsQueryExternal query,
        CancellationToken cancellationToken);

    Task<GetWorkflowsSigningWorkflowDetailsQueryResponseExternal> GetWorkflows(
        GetWorkflowsSigningWorkflowDetailsQueryExternal query,
        CancellationToken cancellationToken);
}
