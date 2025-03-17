using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives.Types;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives;

public sealed class SigningArchiveInternal
{
    internal SigningArchiveInternal(Id<AttachmentInternal> id, SigningArchiveTypeInternal type)
    {
        Id = id;
        Type = type;
    }

    public Id<AttachmentInternal> Id { get; }
    public SigningArchiveTypeInternal Type { get; }
}
