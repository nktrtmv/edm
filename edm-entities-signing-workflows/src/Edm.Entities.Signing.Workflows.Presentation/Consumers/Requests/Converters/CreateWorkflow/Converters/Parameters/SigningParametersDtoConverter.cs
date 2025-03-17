using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Electronics;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parameters.Electronics;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parameters;

internal static class SigningParametersDtoConverter
{
    internal static SigningParametersInternal ToInternal(SigningParametersDto parameters)
    {
        Id<UserInternal>? documentClerkId =
            NullableConverter.Convert(parameters.DocumentClerkId, IdConverterFrom<UserInternal>.FromString);

        SigningElectronicParametersInternal? electronic = NullableConverter.Convert(parameters.Electronic, SigningElectronicParametersDtoConverter.ToInternal);

        var result = new SigningParametersInternal(documentClerkId, electronic);

        return result;
    }
}
