using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Electronics;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parameters.Electronics;

internal static class SigningElectronicParametersDtoConverter
{
    internal static SigningElectronicParametersInternal ToInternal(SigningElectronicParametersDto parameters)
    {
        UtcDateTime<EntityInternal> entityDate =
            UtcDateTimeConverterFrom<EntityInternal>.FromTimestamp(parameters.EntityDate);

        Id<AttachmentInternal>[] documentsIds =
            parameters.DocumentsAttachmentsIds.Select(IdConverterFrom<AttachmentInternal>.FromString).ToArray();

        var result = new SigningElectronicParametersInternal(parameters.EntityName, parameters.EntityNumber, entityDate, documentsIds);

        return result;
    }
}
