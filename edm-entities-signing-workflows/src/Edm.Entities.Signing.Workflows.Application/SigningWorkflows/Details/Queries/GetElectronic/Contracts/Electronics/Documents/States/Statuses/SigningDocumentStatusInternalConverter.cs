using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States.Statuses;

internal static class SigningDocumentStatusInternalConverter
{
    internal static SigningDocumentStatusInternal FromDomain(SigningDocumentStatus status)
    {
        SigningDocumentStatusInternal result = status switch
        {
            SigningDocumentStatus.PendingSelfSigning => SigningDocumentStatusInternal.PendingSelfSigning,
            SigningDocumentStatus.SignedBySelf => SigningDocumentStatusInternal.SignedBySelf,
            SigningDocumentStatus.ReadyForSending => SigningDocumentStatusInternal.ReadyForSending,
            SigningDocumentStatus.RequiredToSign => SigningDocumentStatusInternal.RequiredToSign,
            SigningDocumentStatus.Sent => SigningDocumentStatusInternal.Sent,
            SigningDocumentStatus.InProcess => SigningDocumentStatusInternal.InProcess,
            SigningDocumentStatus.Signed => SigningDocumentStatusInternal.Signed,
            SigningDocumentStatus.Rejected => SigningDocumentStatusInternal.Rejected,
            SigningDocumentStatus.Error => SigningDocumentStatusInternal.Error,
            SigningDocumentStatus.RevocationRequested => SigningDocumentStatusInternal.RevocationRequested,
            SigningDocumentStatus.RevocationRequired => SigningDocumentStatusInternal.RevocationRequired,
            SigningDocumentStatus.Revoked => SigningDocumentStatusInternal.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
