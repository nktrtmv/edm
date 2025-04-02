using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Documents.States.Statuses;

internal static class SigningDocumentStatusDtoConverter
{
    internal static SigningDocumentStatusDto FromInternal(SigningDocumentStatusInternal status)
    {
        SigningDocumentStatusDto result = status switch
        {
            SigningDocumentStatusInternal.PendingSelfSigning => SigningDocumentStatusDto.PendingSelfSigning,
            SigningDocumentStatusInternal.SignedBySelf => SigningDocumentStatusDto.SignedBySelf,
            SigningDocumentStatusInternal.ReadyForSending => SigningDocumentStatusDto.ReadyForSending,
            SigningDocumentStatusInternal.RequiredToSign => SigningDocumentStatusDto.RequiredToSign,
            SigningDocumentStatusInternal.Sent => SigningDocumentStatusDto.Sent,
            SigningDocumentStatusInternal.InProcess => SigningDocumentStatusDto.InProcess,
            SigningDocumentStatusInternal.Signed => SigningDocumentStatusDto.Signed,
            SigningDocumentStatusInternal.Rejected => SigningDocumentStatusDto.Rejected,
            SigningDocumentStatusInternal.Error => SigningDocumentStatusDto.Error,
            SigningDocumentStatusInternal.RevocationRequested => SigningDocumentStatusDto.RevocationRequested,
            SigningDocumentStatusInternal.RevocationRequired => SigningDocumentStatusDto.RevocationRequired,
            SigningDocumentStatusInternal.Revoked => SigningDocumentStatusDto.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
