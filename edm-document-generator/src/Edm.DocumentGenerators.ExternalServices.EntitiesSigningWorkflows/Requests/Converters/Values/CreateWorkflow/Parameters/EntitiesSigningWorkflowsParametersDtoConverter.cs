using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parameters.Electronics;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parameters;

internal static class EntitiesSigningWorkflowsParametersDtoConverter
{
    internal static SigningParametersDto FromDomain(DocumentSigningParameters parameters)
    {
        string? documentClerkId = NullableConverter.Convert(parameters.DocumentClerkId, IdConverterTo.ToString);

        SigningElectronicParametersDto? electronic =
            NullableConverter.Convert(parameters.Electronic, EntitiesSigningWorkflowsElectronicParametersDtoConverter.FromDomain);

        var result = new SigningParametersDto
        {
            DocumentClerkId = documentClerkId,
            Electronic = electronic
        };

        return result;
    }
}
