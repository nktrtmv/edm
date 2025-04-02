using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.Factories;

public static class SigningStageStateFactory
{
    public static SigningStageState CreateNew()
    {
        SigningStageState result = CreateFrom(SigningStageStatus.NotStarted);

        return result;
    }

    public static SigningStageState CreateFrom(SigningStageStatus status)
    {
        UtcDateTime<SigningStage> statusChangedAt = UtcDateTime<SigningStage>.Now;

        SigningStageState result = CreateFromDb(status, statusChangedAt);

        return result;
    }

    public static SigningStageState CreateFromDb(SigningStageStatus status, UtcDateTime<SigningStage> statusChangedAt)
    {
        var result = new SigningStageState(status, statusChangedAt);

        return result;
    }
}
