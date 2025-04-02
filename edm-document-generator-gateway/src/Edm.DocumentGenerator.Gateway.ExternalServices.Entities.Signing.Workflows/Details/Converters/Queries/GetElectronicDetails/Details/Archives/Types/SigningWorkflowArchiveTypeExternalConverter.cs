using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Archives.Types;

internal static class SigningWorkflowArchiveTypeExternalConverter
{
    internal static SigningWorkflowArchiveTypeExternal FromDto(SigningArchiveTypeDto type)
    {
        var result = type switch
        {
            SigningArchiveTypeDto.DigitallySignedDocuments => SigningWorkflowArchiveTypeExternal.DigitallySignedDocuments,
            SigningArchiveTypeDto.PrintForms => SigningWorkflowArchiveTypeExternal.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
