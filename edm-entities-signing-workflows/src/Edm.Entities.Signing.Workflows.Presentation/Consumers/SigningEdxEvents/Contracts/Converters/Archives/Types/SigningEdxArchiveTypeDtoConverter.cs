using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.ValueObjects.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Archives.Types;

internal static class SigningEdxArchiveTypeDtoConverter
{
    internal static SigningArchiveType ToDomain(SigningEdxArchiveTypeDto type)
    {
        SigningArchiveType result = type switch
        {
            SigningEdxArchiveTypeDto.DigitallySignedDocuments => SigningArchiveType.DigitallySignedDocuments,
            SigningEdxArchiveTypeDto.PrintForms => SigningArchiveType.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
