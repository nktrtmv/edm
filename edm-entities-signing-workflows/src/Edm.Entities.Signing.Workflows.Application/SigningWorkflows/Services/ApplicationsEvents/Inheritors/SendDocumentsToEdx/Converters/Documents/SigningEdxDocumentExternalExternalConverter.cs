using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Documents;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Documents;

internal static class SigningEdxDocumentExternalExternalConverter
{
    internal static SigningEdxDocumentExternal FromDomain(SigningDocument document)
    {
        Id<AttachmentExternal> documentId = IdConverterFrom<AttachmentExternal>.From(document.DocumentId);

        Id<AttachmentExternal> signatureId = IdConverterFrom<AttachmentExternal>.From(document.SignatureId!.Value);

        var result = new SigningEdxDocumentExternal(documentId, signatureId);

        return result;
    }
}
