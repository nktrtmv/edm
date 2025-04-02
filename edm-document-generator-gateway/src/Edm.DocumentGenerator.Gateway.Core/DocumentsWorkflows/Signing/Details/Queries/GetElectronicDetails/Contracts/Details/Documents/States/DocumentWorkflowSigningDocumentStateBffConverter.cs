using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States;

internal static class DocumentWorkflowSigningDocumentStateBffConverter
{
    internal static DocumentWorkflowSigningDocumentStateBff FromExternal(SigningWorkflowDocumentStateExternal external)
    {
        var status = DocumentWorkflowSigningDocumentStatusBffConverter.FromExternal(external.Status);

        var result = new DocumentWorkflowSigningDocumentStateBff
        {
            Status = status,
            StatusDescription = external.StatusDescription,
            StatusChangedAt = external.StatusChangedAt
        };

        return result;
    }
}
