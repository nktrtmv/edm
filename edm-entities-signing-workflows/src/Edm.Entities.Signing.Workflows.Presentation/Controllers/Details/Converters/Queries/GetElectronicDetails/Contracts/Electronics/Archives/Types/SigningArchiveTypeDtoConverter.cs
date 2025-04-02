using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Archives.Types;

internal static class SigningArchiveTypeDtoConverter
{
    internal static SigningArchiveTypeDto FromDomain(SigningArchiveTypeInternal type)
    {
        SigningArchiveTypeDto result = type switch
        {
            SigningArchiveTypeInternal.DigitallySignedDocuments => SigningArchiveTypeDto.DigitallySignedDocuments,
            SigningArchiveTypeInternal.PrintForms => SigningArchiveTypeDto.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
