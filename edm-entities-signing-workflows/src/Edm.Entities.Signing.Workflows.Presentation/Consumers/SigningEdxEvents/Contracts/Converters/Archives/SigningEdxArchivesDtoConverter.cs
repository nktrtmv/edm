using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.ValueObjects.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Archives.Types;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Archives;

internal static class SigningEdxArchivesDtoConverter
{
    internal static SigningArchive ToDomain(SigningEdxArchiveDto archive)
    {
        Id<Attachment> id = IdConverterFrom<Attachment>.FromString(archive.AttachmentId);

        SigningArchiveType type = SigningEdxArchiveTypeDtoConverter.ToDomain(archive.Type);

        SigningArchive result = SigningArchiveFactory.CreateFrom(id, type);

        return result;
    }
}
