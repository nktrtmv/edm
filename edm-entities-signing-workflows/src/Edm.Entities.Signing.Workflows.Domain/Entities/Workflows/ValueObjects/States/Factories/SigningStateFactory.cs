using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Factories;

public static class SigningStateFactory
{
    public static SigningState CreateNew(SigningParty[] parties)
    {
        SigningStage[] stages = parties.Select(SigningStageFactory.CreateNew).ToArray();

        const SigningStatus status = SigningStatus.NotStarted;

        UtcDateTime<SigningState> statusChangedAt = UtcDateTime<SigningState>.Now;

        SigningState result = CreateFromDb(stages, status, statusChangedAt);

        return result;
    }

    public static SigningState CreateFromDb(
        SigningStage[] stages,
        SigningStatus status,
        UtcDateTime<SigningState> statusChangedAt)
    {
        var result = new SigningState(stages, status, statusChangedAt);

        return result;
    }
}
