using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts.DocumentsToSign;

internal static class SigningWorkflowDocumentToSignDtoConverter
{
    internal static SigningWorkflowDocumentToSignDto FromDto(SigningDocumentToSignDto document)
    {
        var attachmentId = Guid.Parse(document.DocumentAttachmentId);
        var result = new SigningWorkflowDocumentToSignDto(attachmentId);

        return result;
    }
}
