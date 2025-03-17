using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.ValueObjects.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Archives.Types;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Archives;

internal static class SigningArchiveDbConverter
{
    internal static SigningArchiveDb FromDomain(SigningArchive archive)
    {
        var attachmentId = IdConverterTo.ToString(archive.Id);

        SigningArchiveTypeDb type = SigningArchiveTypeDbConverter.FromDomain(archive.Type);

        var result = new SigningArchiveDb
        {
            AttachmentId = attachmentId,
            Type = type
        };

        return result;
    }

    internal static SigningArchive ToDomain(SigningArchiveDb archive)
    {
        Id<Attachment> id = IdConverterFrom<Attachment>.FromString(archive.AttachmentId);

        SigningArchiveType type = SigningArchiveTypeDbConverter.ToDomain(archive.Type);

        SigningArchive result = SigningArchiveFactory.CreateFromDb(id, type);

        return result;
    }
}
