using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetElectronicDetails.Details.Documents.States.
    Statuses;

internal static class SigningWorkflowDocumentStatusExternalConverter
{
    internal static SigningWorkflowDocumentStatusExternal FromDto(SigningDocumentStatusDto status)
    {
        var result = status switch
        {
            SigningDocumentStatusDto.PendingSelfSigning => SigningWorkflowDocumentStatusExternal.PendingSelfSigning,
            SigningDocumentStatusDto.SignedBySelf => SigningWorkflowDocumentStatusExternal.SignedBySelf,
            SigningDocumentStatusDto.ReadyForSending => SigningWorkflowDocumentStatusExternal.ReadyForSending,
            SigningDocumentStatusDto.RequiredToSign => SigningWorkflowDocumentStatusExternal.RequiredToSign,
            SigningDocumentStatusDto.Sent => SigningWorkflowDocumentStatusExternal.Sent,
            SigningDocumentStatusDto.InProcess => SigningWorkflowDocumentStatusExternal.InProcess,
            SigningDocumentStatusDto.Signed => SigningWorkflowDocumentStatusExternal.Signed,
            SigningDocumentStatusDto.Rejected => SigningWorkflowDocumentStatusExternal.Rejected,
            SigningDocumentStatusDto.Error => SigningWorkflowDocumentStatusExternal.Error,
            SigningDocumentStatusDto.RevocationRequired => SigningWorkflowDocumentStatusExternal.RevocationRequired,
            SigningDocumentStatusDto.RevocationRequested => SigningWorkflowDocumentStatusExternal.RevocationRequested,
            SigningDocumentStatusDto.Revoked => SigningWorkflowDocumentStatusExternal.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
