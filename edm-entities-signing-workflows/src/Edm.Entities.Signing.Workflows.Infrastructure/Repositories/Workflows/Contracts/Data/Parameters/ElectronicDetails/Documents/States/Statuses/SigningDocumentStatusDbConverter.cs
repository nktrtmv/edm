using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Documents.States.Statuses;

internal static class SigningDocumentStatusDbConverter
{
    internal static SigningDocumentStatusDb FromDomain(SigningDocumentStatus status)
    {
        SigningDocumentStatusDb result = status switch
        {
            SigningDocumentStatus.PendingSelfSigning => SigningDocumentStatusDb.PendingSelfSigning,
            SigningDocumentStatus.SignedBySelf => SigningDocumentStatusDb.SignedBySelf,
            SigningDocumentStatus.ReadyForSending => SigningDocumentStatusDb.ReadyForSending,
            SigningDocumentStatus.RequiredToSign => SigningDocumentStatusDb.RequiredToSign,
            SigningDocumentStatus.Sent => SigningDocumentStatusDb.Sent,
            SigningDocumentStatus.InProcess => SigningDocumentStatusDb.InProcess,
            SigningDocumentStatus.Signed => SigningDocumentStatusDb.Signed,
            SigningDocumentStatus.Rejected => SigningDocumentStatusDb.Rejected,
            SigningDocumentStatus.Error => SigningDocumentStatusDb.Error,
            SigningDocumentStatus.RevocationRequested => SigningDocumentStatusDb.RevocationRequested,
            SigningDocumentStatus.RevocationRequired => SigningDocumentStatusDb.RevocationRequired,
            SigningDocumentStatus.Revoked => SigningDocumentStatusDb.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static SigningDocumentStatus ToDomain(SigningDocumentStatusDb status)
    {
        SigningDocumentStatus result = status switch
        {
            SigningDocumentStatusDb.PendingSelfSigning => SigningDocumentStatus.PendingSelfSigning,
            SigningDocumentStatusDb.SignedBySelf => SigningDocumentStatus.SignedBySelf,
            SigningDocumentStatusDb.ReadyForSending => SigningDocumentStatus.ReadyForSending,
            SigningDocumentStatusDb.RequiredToSign => SigningDocumentStatus.RequiredToSign,
            SigningDocumentStatusDb.Sent => SigningDocumentStatus.Sent,
            SigningDocumentStatusDb.InProcess => SigningDocumentStatus.InProcess,
            SigningDocumentStatusDb.Signed => SigningDocumentStatus.Signed,
            SigningDocumentStatusDb.Rejected => SigningDocumentStatus.Rejected,
            SigningDocumentStatusDb.Error => SigningDocumentStatus.Error,
            SigningDocumentStatusDb.RevocationRequested => SigningDocumentStatus.RevocationRequested,
            SigningDocumentStatusDb.RevocationRequired => SigningDocumentStatus.RevocationRequired,
            SigningDocumentStatusDb.Revoked => SigningDocumentStatus.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
