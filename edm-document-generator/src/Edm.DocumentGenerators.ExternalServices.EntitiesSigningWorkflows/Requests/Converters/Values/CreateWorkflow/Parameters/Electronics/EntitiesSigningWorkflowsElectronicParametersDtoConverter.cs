using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters.
    Electronics;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parameters.Electronics;

internal static class EntitiesSigningWorkflowsElectronicParametersDtoConverter
{
    internal static SigningElectronicParametersDto FromDomain(DocumentSigningElectronicParameters parameters)
    {
        Timestamp entityDate = UtcDateTimeConverterTo.ToTimeStamp(parameters.DocumentDate);

        string[] documentsAttachmentsIds = parameters.DocumentsAttachmentsIds.Select(IdConverterTo.ToString).ToArray();

        var result = new SigningElectronicParametersDto
        {
            EntityName = parameters.DocumentName,
            EntityNumber = parameters.DocumentNumber,
            EntityDate = entityDate,
            DocumentsAttachmentsIds = { documentsAttachmentsIds }
        };

        return result;
    }
}
