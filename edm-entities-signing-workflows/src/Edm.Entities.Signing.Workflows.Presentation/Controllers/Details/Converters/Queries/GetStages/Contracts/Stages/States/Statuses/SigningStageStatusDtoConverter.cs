using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages.States.Statuses;

internal static class SigningStageStatusDtoConverter
{
    internal static SigningStageStatusDto FromInternal(SigningStageStatusInternal status)
    {
        SigningStageStatusDto result = status switch
        {
            SigningStageStatusInternal.NotStarted => SigningStageStatusDto.NotStarted,
            SigningStageStatusInternal.InProgress => SigningStageStatusDto.InProgress,
            SigningStageStatusInternal.Completed => SigningStageStatusDto.Completed,
            SigningStageStatusInternal.Signed => SigningStageStatusDto.Signed,
            SigningStageStatusInternal.Rejected => SigningStageStatusDto.Rejected,
            SigningStageStatusInternal.ReturnedToRework => SigningStageStatusDto.ReturnedToRework,
            SigningStageStatusInternal.Withdrawn => SigningStageStatusDto.Withdrawn,
            SigningStageStatusInternal.Cancelled => SigningStageStatusDto.Cancelled,
            SigningStageStatusInternal.Error => SigningStageStatusDto.Error,
            SigningStageStatusInternal.Revocation => SigningStageStatusDto.Revocation,
            SigningStageStatusInternal.Revoked => SigningStageStatusDto.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
