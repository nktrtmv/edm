using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.States.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.States;

internal static class SigningStageStateDbConverter
{
    internal static SigningStageStateDb FromDomain(SigningStageState state)
    {
        SigningStageStatusDb status = SigningStageStatusDbConverter.FromDomain(state.Status);

        Timestamp statusChangedAt = UtcDateTimeConverterTo.ToTimeStamp(state.StatusChangedAt);

        var result = new SigningStageStateDb
        {
            Status = status,
            StatusChangedAt = statusChangedAt
        };

        return result;
    }

    internal static SigningStageState ToDomain(SigningStageStateDb state)
    {
        SigningStageStatus status =
            SigningStageStatusDbConverter.ToDomain(state.Status);

        UtcDateTime<SigningStage> statusChangedAt =
            UtcDateTimeConverterFrom<SigningStage>.FromTimestamp(state.StatusChangedAt);

        SigningStageState result = SigningStageStateFactory.CreateFromDb(status, statusChangedAt);

        return result;
    }
}
