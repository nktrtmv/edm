using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Archives;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details;

internal static class DocumentWorkflowSigningElectronicDetailsBffConverter
{
    internal static DocumentWorkflowSigningElectronicDetailsBff FromExternal(
        SigningWorkflowElectronicDetailsExternal details,
        string workflowId)
    {
        var archives =
            details.Archives.Select(DocumentWorkflowSigningArchiveBffConverter.FromExternal).ToArray();

        DocumentWorkflowSigningDocumentBff[] documents =
            details.Documents.Select(DocumentWorkflowSigningDocumentBffConverter.FromExternal).ToArray();

        var result = new DocumentWorkflowSigningElectronicDetailsBff
        {
            WorkflowId = workflowId,
            Archives = archives,
            Documents = documents
        };

        return result;
    }
}
