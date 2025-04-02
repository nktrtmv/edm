using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters.
    Electronics;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.Parameters.
    Electronics;

internal static class CreateWorkflowEntitiesSigningWorkflowsRequestElectronicParametersDbConverter
{
    internal static CreateWorkflowEntitiesSigningWorkflowsRequestElectronicParametersDb FromDomain(DocumentSigningElectronicParameters parameters)
    {
        Timestamp documentDate = UtcDateTimeConverterTo.ToTimeStamp(parameters.DocumentDate);

        string[] documentsAttachmentsIds = parameters.DocumentsAttachmentsIds.Select(IdConverterTo.ToString).ToArray();

        var result = new CreateWorkflowEntitiesSigningWorkflowsRequestElectronicParametersDb
        {
            DocumentName = parameters.DocumentName,
            DocumentNumber = parameters.DocumentNumber,
            DocumentDate = documentDate,
            DocumentsAttachmentsIds = { documentsAttachmentsIds }
        };

        return result;
    }

    internal static DocumentSigningElectronicParameters ToDomain(CreateWorkflowEntitiesSigningWorkflowsRequestElectronicParametersDb parameters)
    {
        UtcDateTime<DocumentSigningElectronicParameters> documentDate =
            UtcDateTimeConverterFrom<DocumentSigningElectronicParameters>.FromTimestamp(parameters.DocumentDate);

        Id<Attachment>[] documentsAttachmentsIds =
            parameters.DocumentsAttachmentsIds.Select(IdConverterFrom<Attachment>.FromString).ToArray();

        var result = new DocumentSigningElectronicParameters(
            parameters.DocumentName,
            parameters.DocumentNumber,
            documentDate,
            documentsAttachmentsIds);

        return result;
    }
}
