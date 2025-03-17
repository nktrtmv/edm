using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States.Statuses;

internal static class SigningStageStatusInternalConverter
{
    internal static SigningStageStatusInternal FromDomain(SigningStageStatus status)
    {
        SigningStageStatusInternal result = status switch
        {
            SigningStageStatus.NotStarted => SigningStageStatusInternal.NotStarted,
            SigningStageStatus.InProgress => SigningStageStatusInternal.InProgress,
            SigningStageStatus.Completed => SigningStageStatusInternal.Completed,
            SigningStageStatus.Signed => SigningStageStatusInternal.Signed,
            SigningStageStatus.Rejected => SigningStageStatusInternal.Rejected,
            SigningStageStatus.ReturnedToRework => SigningStageStatusInternal.ReturnedToRework,
            SigningStageStatus.Withdrawn => SigningStageStatusInternal.Withdrawn,
            SigningStageStatus.Cancelled => SigningStageStatusInternal.Cancelled,
            SigningStageStatus.Error => SigningStageStatusInternal.Error,
            SigningStageStatus.Revocation => SigningStageStatusInternal.Revocation,
            SigningStageStatus.Revoked => SigningStageStatusInternal.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
