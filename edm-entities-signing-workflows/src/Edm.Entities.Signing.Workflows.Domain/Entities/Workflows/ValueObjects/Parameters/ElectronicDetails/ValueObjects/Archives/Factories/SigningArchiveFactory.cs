using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.ValueObjects.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.Factories;

public static class SigningArchiveFactory
{
    public static SigningArchive CreateFrom(Id<Attachment> id, SigningArchiveType type)
    {
        SigningArchive result = CreateFromDb(id, type);

        return result;
    }

    public static SigningArchive CreateFromDb(Id<Attachment> id, SigningArchiveType type)
    {
        var result = new SigningArchive(id, type);

        return result;
    }
}
