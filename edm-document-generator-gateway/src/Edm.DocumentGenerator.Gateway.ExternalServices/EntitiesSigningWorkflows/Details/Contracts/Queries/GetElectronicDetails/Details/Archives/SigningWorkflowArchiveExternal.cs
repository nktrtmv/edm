using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives.Types;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives;

public sealed class SigningWorkflowArchiveExternal
{
    public SigningWorkflowArchiveExternal(string attachmentId, SigningWorkflowArchiveTypeExternal type)
    {
        AttachmentId = attachmentId;
        Type = type;
    }

    public string AttachmentId { get; }
    public SigningWorkflowArchiveTypeExternal Type { get; }
}
