using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails;

internal static class GetElectronicDetailsSigningWorkflowDetailsQueryExternalConverter
{
    internal static GetSigningElectronicDetailsQuery ToDto(GetElectronicDetailsSigningWorkflowDetailsQueryExternal query)
    {
        var result = new GetSigningElectronicDetailsQuery
        {
            WorkflowId = query.WorkflowId
        };

        return result;
    }
}
