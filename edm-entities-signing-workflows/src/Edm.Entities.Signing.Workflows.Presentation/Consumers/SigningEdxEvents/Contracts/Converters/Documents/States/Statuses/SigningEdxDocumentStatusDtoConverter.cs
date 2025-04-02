using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Documents.States.Statuses;

internal static class SigningEdxDocumentStatusDtoConverter
{
    internal static SigningDocumentStatus ToDomain(SigningEdxDocumentStatusDto status)
    {
        SigningDocumentStatus result = status switch
        {
            SigningEdxDocumentStatusDto.ReadyForSending => SigningDocumentStatus.ReadyForSending,
            SigningEdxDocumentStatusDto.RequiredToSign => SigningDocumentStatus.RequiredToSign,
            SigningEdxDocumentStatusDto.Sent => SigningDocumentStatus.Sent,
            SigningEdxDocumentStatusDto.InProcess => SigningDocumentStatus.InProcess,
            SigningEdxDocumentStatusDto.Signed => SigningDocumentStatus.Signed,
            SigningEdxDocumentStatusDto.Rejected => SigningDocumentStatus.Rejected,
            SigningEdxDocumentStatusDto.Error => SigningDocumentStatus.Error,
            SigningEdxDocumentStatusDto.RevocationRequested => SigningDocumentStatus.RevocationRequested,
            SigningEdxDocumentStatusDto.RevocationRequired => SigningDocumentStatus.RevocationRequired,
            SigningEdxDocumentStatusDto.Revoked => SigningDocumentStatus.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
