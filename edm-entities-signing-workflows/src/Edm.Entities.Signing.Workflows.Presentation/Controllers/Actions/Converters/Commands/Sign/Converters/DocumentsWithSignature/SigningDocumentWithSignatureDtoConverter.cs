using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts.Contracts.DocumentsWithSignature;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.Sign.Converters.DocumentsWithSignature;

internal static class SigningDocumentWithSignatureDtoConverter
{
    internal static SigningDocumentWithSignatureInternal ToInternal(SigningDocumentWithSignatureDto document)
    {
        Id<AttachmentInternal> documentId = IdConverterFrom<AttachmentInternal>.FromString(document.DocumentAttachmentId);

        Id<AttachmentInternal> signatureId = IdConverterFrom<AttachmentInternal>.FromString(document.SignatureAttachmentId);

        var result = new SigningDocumentWithSignatureInternal(documentId, signatureId);

        return result;
    }
}
