using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Electronics;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;

internal static class SigningParametersInternalConverter
{
    internal static SigningParameters ToDomain(SigningParametersInternal parameters)
    {
        Id<User>? documentClerkId =
            NullableConverter.Convert(parameters.DocumentClerkId, IdConverterFrom<User>.From);

        SigningElectronicDetails? electronicDetails =
            NullableConverter.Convert(parameters.ElectronicDetails, SigningElectronicParametersInternalConverter.ToDomain);

        var result = new SigningParameters(documentClerkId, electronicDetails);

        return result;
    }
}
