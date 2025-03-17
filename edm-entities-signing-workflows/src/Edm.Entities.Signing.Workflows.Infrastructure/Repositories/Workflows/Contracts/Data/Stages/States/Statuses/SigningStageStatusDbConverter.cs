using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.States.Statuses;

internal static class SigningStageStatusDbConverter
{
    internal static SigningStageStatusDb FromDomain(SigningStageStatus status)
    {
        SigningStageStatusDb result = status switch
        {
            SigningStageStatus.NotStarted => SigningStageStatusDb.NotStarted,
            SigningStageStatus.InProgress => SigningStageStatusDb.InProgress,
            SigningStageStatus.Completed => SigningStageStatusDb.Completed,
            SigningStageStatus.Signed => SigningStageStatusDb.Signed,
            SigningStageStatus.Rejected => SigningStageStatusDb.Rejected,
            SigningStageStatus.ReturnedToRework => SigningStageStatusDb.ReturnedToRework,
            SigningStageStatus.Withdrawn => SigningStageStatusDb.Withdrawn,
            SigningStageStatus.Cancelled => SigningStageStatusDb.Cancelled,
            SigningStageStatus.Error => SigningStageStatusDb.Error,
            SigningStageStatus.Revocation => SigningStageStatusDb.Revocation,
            SigningStageStatus.Revoked => SigningStageStatusDb.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static SigningStageStatus ToDomain(SigningStageStatusDb status)
    {
        SigningStageStatus result = status switch
        {
            SigningStageStatusDb.NotStarted => SigningStageStatus.NotStarted,
            SigningStageStatusDb.InProgress => SigningStageStatus.InProgress,
            SigningStageStatusDb.Completed => SigningStageStatus.Completed,
            SigningStageStatusDb.Signed => SigningStageStatus.Signed,
            SigningStageStatusDb.Rejected => SigningStageStatus.Rejected,
            SigningStageStatusDb.ReturnedToRework => SigningStageStatus.ReturnedToRework,
            SigningStageStatusDb.Withdrawn => SigningStageStatus.Withdrawn,
            SigningStageStatusDb.Cancelled => SigningStageStatus.Cancelled,
            SigningStageStatusDb.Error => SigningStageStatus.Error,
            SigningStageStatusDb.Revocation => SigningStageStatus.Revocation,
            SigningStageStatusDb.Revoked => SigningStageStatus.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
