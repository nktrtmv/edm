using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Documents.States;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Documents;

internal static class SigningWorkflowDocumentExternalConverter
{
    internal static SigningWorkflowDocumentExternal FromDto(SigningDocumentDto document)
    {
        var state = SigningWorkflowDocumentStateExternalConverter.FromDto(document.State);

        var result = new SigningWorkflowDocumentExternal(
            document.EdoId,
            document.DocumentAttachmentId,
            document.SignatureAttachmentId,
            state);

        return result;
    }
}
