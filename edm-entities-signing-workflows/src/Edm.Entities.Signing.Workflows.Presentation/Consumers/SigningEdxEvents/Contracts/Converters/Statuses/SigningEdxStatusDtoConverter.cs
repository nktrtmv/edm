using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Statuses;

internal static class SigningEdxStatusDtoConverter
{
    internal static SigningStageStatus ToDomain(SigningEdxStatusDto status)
    {
        SigningStageStatus result = status switch
        {
            SigningEdxStatusDto.InProgress => SigningStageStatus.InProgress,
            SigningEdxStatusDto.Signed => SigningStageStatus.Signed,
            SigningEdxStatusDto.Rejected => SigningStageStatus.Rejected,
            SigningEdxStatusDto.Error => SigningStageStatus.Error,
            SigningEdxStatusDto.Revocation => SigningStageStatus.Revocation,
            SigningEdxStatusDto.Revoked => SigningStageStatus.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
