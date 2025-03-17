using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Electronics;

internal static class SigningElectronicParametersInternalConverter
{
    internal static SigningElectronicDetails ToDomain(SigningElectronicParametersInternal parameters)
    {
        UtcDateTime<Entity> date = UtcDateTimeConverterFrom<Entity>.From(parameters.EntityDate);

        Id<Attachment>[] documentsIds = parameters.DocumentsIds.Select(IdConverterFrom<Attachment>.From).ToArray();

        SigningElectronicDetails result = SigningElectronicDetailsFactory.CreateFrom(parameters.EntityName, parameters.EntityNumber, date, documentsIds);

        return result;
    }
}
