using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.ValueObjects.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Archives.Types;

internal static class SigningArchiveTypeDbConverter
{
    internal static SigningArchiveTypeDb FromDomain(SigningArchiveType type)
    {
        SigningArchiveTypeDb result = type switch
        {
            SigningArchiveType.DigitallySignedDocuments => SigningArchiveTypeDb.DigitallySignedDocuments,
            SigningArchiveType.PrintForms => SigningArchiveTypeDb.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static SigningArchiveType ToDomain(SigningArchiveTypeDb type)
    {
        SigningArchiveType result = type switch
        {
            SigningArchiveTypeDb.DigitallySignedDocuments => SigningArchiveType.DigitallySignedDocuments,
            SigningArchiveTypeDb.PrintForms => SigningArchiveType.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
