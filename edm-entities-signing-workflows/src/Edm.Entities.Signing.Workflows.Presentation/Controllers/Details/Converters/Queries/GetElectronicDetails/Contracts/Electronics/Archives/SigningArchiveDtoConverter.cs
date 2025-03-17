using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Archives.Types;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Archives;

internal static class SigningArchiveDtoConverter
{
    internal static SigningArchiveDto FromInternal(SigningArchiveInternal archive)
    {
        var attachmentId = IdConverterTo.ToString(archive.Id);

        SigningArchiveTypeDto type = SigningArchiveTypeDtoConverter.FromDomain(archive.Type);

        var result = new SigningArchiveDto
        {
            AttachmentId = attachmentId,
            Type = type
        };

        return result;
    }
}
