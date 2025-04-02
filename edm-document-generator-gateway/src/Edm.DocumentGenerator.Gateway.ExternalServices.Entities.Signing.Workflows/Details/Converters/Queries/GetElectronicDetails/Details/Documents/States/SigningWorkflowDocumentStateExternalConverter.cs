using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Documents.States.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Documents.States;

internal static class SigningWorkflowDocumentStateExternalConverter
{
    internal static SigningWorkflowDocumentStateExternal FromDto(SigningDocumentStateDto state)
    {
        var status = SigningWorkflowDocumentStatusExternalConverter.FromDto(state.Status);

        var statusChangedAt = state.StatusChangedAt.ToDateTime();

        var result = new SigningWorkflowDocumentStateExternal(status, state.StatusDescription, statusChangedAt);

        return result;
    }
}
