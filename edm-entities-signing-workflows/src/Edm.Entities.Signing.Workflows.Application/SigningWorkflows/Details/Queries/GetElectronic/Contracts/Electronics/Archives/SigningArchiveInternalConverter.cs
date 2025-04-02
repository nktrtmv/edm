using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives.Types;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives;

internal static class SigningArchivesInternalConverter
{
    internal static SigningArchiveInternal FromDomain(SigningArchive archive)
    {
        Id<AttachmentInternal> id = IdConverterFrom<AttachmentInternal>.From(archive.Id);

        SigningArchiveTypeInternal type = SigningArchiveTypeInternalConverter.FromDomain(archive.Type);

        var result = new SigningArchiveInternal(id, type);

        return result;
    }
}
