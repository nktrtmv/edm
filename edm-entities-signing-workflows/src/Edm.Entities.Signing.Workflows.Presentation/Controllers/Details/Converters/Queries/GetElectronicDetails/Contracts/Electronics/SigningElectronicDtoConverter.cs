using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Archives;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Documents;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics;

internal static class SigningElectronicDtoConverter
{
    internal static SigningElectronicDetailsDto FromInternal(SigningElectronicDetailsInternal details)
    {
        SigningArchiveDto[] archives =
            details.Archives.Select(SigningArchiveDtoConverter.FromInternal).ToArray();

        SigningDocumentDto[] documents =
            details.Documents.Select(SigningDocumentDtoConverter.FromInternal).ToArray();

        var result = new SigningElectronicDetailsDto
        {
            Archives = { archives },
            Documents = { documents }
        };

        return result;
    }
}
