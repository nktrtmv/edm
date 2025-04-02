using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.DocumentsWithSignatures;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Commands.DocumentsWithSignatures;

internal static class SigningWorkflowDocumentWithSignatureExternalConverter
{
    internal static SigningDocumentWithSignatureDto ToDto(SigningWorkflowDocumentWithSignatureExternal document)
    {
        var result = new SigningDocumentWithSignatureDto
        {
            DocumentAttachmentId = document.DocumentAttachmentId,
            SignatureAttachmentId = document.SignatureAttachmentId
        };

        return result;
    }
}
