using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;

public sealed class SigningStageState
{
    internal SigningStageState(SigningStageStatus status, UtcDateTime<SigningStage> statusChangedAt)
    {
        Status = status;
        StatusChangedAt = statusChangedAt;
    }

    public SigningStageStatus Status { get; }
    public UtcDateTime<SigningStage> StatusChangedAt { get; }
}
