using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.
    Parameters.Electronics.Factories;

internal static class DocumentSigningElectronicParametersFactory
{
    internal static DocumentSigningElectronicParameters CreateFrom(
        string documentName,
        string documentNumber,
        UtcDateTime<DocumentSigningElectronicParameters> documentDate,
        Id<Attachment>[] documentsAttachmentsIds)
    {
        var result = new DocumentSigningElectronicParameters(documentName, documentNumber, documentDate, documentsAttachmentsIds);

        return result;
    }
}
