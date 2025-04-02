using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives.ValueObjects.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives.Types;

internal static class SigningArchiveTypeInternalConverter
{
    internal static SigningArchiveTypeInternal FromDomain(SigningArchiveType type)
    {
        SigningArchiveTypeInternal result = type switch
        {
            SigningArchiveType.DigitallySignedDocuments => SigningArchiveTypeInternal.DigitallySignedDocuments,
            SigningArchiveType.PrintForms => SigningArchiveTypeInternal.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
