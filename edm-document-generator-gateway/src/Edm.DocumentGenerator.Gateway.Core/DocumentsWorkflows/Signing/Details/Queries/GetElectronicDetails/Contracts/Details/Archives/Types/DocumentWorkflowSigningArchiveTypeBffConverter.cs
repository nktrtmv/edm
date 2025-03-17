using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Archives.Types;

internal static class DocumentWorkflowSigningArchiveTypeBffConverter
{
    internal static DocumentWorkflowSigningArchiveTypeBff FromExternal(SigningWorkflowArchiveTypeExternal type)
    {
        var result = type switch
        {
            SigningWorkflowArchiveTypeExternal.DigitallySignedDocuments => DocumentWorkflowSigningArchiveTypeBff.DigitallySignedDocuments,
            SigningWorkflowArchiveTypeExternal.PrintForms => DocumentWorkflowSigningArchiveTypeBff.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static SigningWorkflowArchiveTypeExternal ToExternal(DocumentWorkflowSigningArchiveTypeBff type)
    {
        var result = type switch
        {
            DocumentWorkflowSigningArchiveTypeBff.DigitallySignedDocuments => SigningWorkflowArchiveTypeExternal.DigitallySignedDocuments,
            DocumentWorkflowSigningArchiveTypeBff.PrintForms => SigningWorkflowArchiveTypeExternal.PrintForms,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
