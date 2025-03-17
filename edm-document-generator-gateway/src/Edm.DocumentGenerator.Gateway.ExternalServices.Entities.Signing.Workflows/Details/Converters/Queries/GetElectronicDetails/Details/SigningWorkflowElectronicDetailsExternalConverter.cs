using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Archives;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Documents;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details;

internal static class SigningWorkflowElectronicDetailsExternalConverter
{
    internal static SigningWorkflowElectronicDetailsExternal FromDto(SigningElectronicDetailsDto details)
    {
        SigningWorkflowArchiveExternal[] archives =
            details.Archives.Select(SigningWorkflowArchiveExternalConverter.FromDto).ToArray();

        SigningWorkflowDocumentExternal[] documents =
            details.Documents.Select(SigningWorkflowDocumentExternalConverter.FromDto).ToArray();

        var result = new SigningWorkflowElectronicDetailsExternal(archives, documents);

        return result;
    }
}
