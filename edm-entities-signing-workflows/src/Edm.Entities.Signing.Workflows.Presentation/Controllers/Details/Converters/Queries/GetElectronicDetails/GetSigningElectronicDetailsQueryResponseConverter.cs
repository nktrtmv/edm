using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails;

internal static class GetSigningElectronicDetailsQueryResponseConverter
{
    internal static GetSigningElectronicDetailsQueryResponse FromInternal(GetSigningElectronicDetailsQueryInternalResponse response)
    {
        SigningElectronicDetailsDto? details =
            NullableConverter.Convert(response.Details, SigningElectronicDtoConverter.FromInternal);

        var result = new GetSigningElectronicDetailsQueryResponse
        {
            Details = details
        };

        return result;
    }
}
