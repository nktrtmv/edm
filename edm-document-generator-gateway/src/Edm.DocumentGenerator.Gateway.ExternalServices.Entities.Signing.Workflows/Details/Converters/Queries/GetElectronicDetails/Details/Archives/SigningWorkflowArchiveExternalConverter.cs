using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Archives.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Archives;

internal static class SigningWorkflowArchiveExternalConverter
{
    internal static SigningWorkflowArchiveExternal FromDto(SigningArchiveDto archive)
    {
        var attachmentId = archive.AttachmentId;

        var type = SigningWorkflowArchiveTypeExternalConverter.FromDto(archive.Type);

        var result = new SigningWorkflowArchiveExternal(attachmentId, type);

        return result;
    }
}
