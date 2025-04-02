using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;

public sealed class GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternal
{
    public GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternal(SigningWorkflowElectronicDetailsExternal? details)
    {
        Details = details;
    }

    public SigningWorkflowElectronicDetailsExternal? Details { get; }
}
