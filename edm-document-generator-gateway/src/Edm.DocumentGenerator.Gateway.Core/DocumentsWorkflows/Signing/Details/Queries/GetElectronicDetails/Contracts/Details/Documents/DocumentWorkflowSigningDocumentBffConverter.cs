using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents;

internal static class DocumentWorkflowSigningDocumentBffConverter
{
    internal static DocumentWorkflowSigningDocumentBff FromExternal(SigningWorkflowDocumentExternal external)
    {
        var state = DocumentWorkflowSigningDocumentStateBffConverter.FromExternal(external.State);

        var result = new DocumentWorkflowSigningDocumentBff
        {
            EdoId = external.EdoId,
            DocumentAttachmentId = external.DocumentAttachmentId,
            SignatureAttachmentId = external.SignatureAttachmentId,
            State = state
        };

        return result;
    }
}
