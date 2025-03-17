using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Archives.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Archives;

internal static class DocumentWorkflowSigningArchiveBffConverter
{
    internal static DocumentWorkflowSigningArchiveBff FromExternal(SigningWorkflowArchiveExternal archive)
    {
        var type = DocumentWorkflowSigningArchiveTypeBffConverter.FromExternal(archive.Type);

        var result = new DocumentWorkflowSigningArchiveBff
        {
            Type = type
        };

        return result;
    }
}
