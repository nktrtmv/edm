using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails;

internal static class GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternalConverter
{
    internal static GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternal FromDto(GetSigningElectronicDetailsQueryResponse response)
    {
        var details = NullableConverter.Convert(response.Details, SigningWorkflowElectronicDetailsExternalConverter.FromDto);

        var result = new GetElectronicDetailsSigningWorkflowDetailsQueryResponseExternal(details);

        return result;
    }
}
