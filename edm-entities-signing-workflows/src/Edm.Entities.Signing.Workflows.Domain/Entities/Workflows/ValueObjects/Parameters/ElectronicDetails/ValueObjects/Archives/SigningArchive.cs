using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.ValueObjects.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;

public sealed class SigningArchive
{
    internal SigningArchive(Id<Attachment> id, SigningArchiveType type)
    {
        Id = id;
        Type = type;
    }

    public Id<Attachment> Id { get; }
    public SigningArchiveType Type { get; }
}
