using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.
    Parameters.Electronics;

public sealed class DocumentSigningElectronicParameters
{
    public DocumentSigningElectronicParameters(
        string documentName,
        string documentNumber,
        UtcDateTime<DocumentSigningElectronicParameters> documentDate,
        Id<Attachment>[] documentsAttachmentsIds)
    {
        DocumentName = documentName;
        DocumentNumber = documentNumber;
        DocumentDate = documentDate;
        DocumentsAttachmentsIds = documentsAttachmentsIds;
    }

    public string DocumentName { get; }
    public string DocumentNumber { get; }
    public UtcDateTime<DocumentSigningElectronicParameters> DocumentDate { get; }
    public Id<Attachment>[] DocumentsAttachmentsIds { get; }
}
