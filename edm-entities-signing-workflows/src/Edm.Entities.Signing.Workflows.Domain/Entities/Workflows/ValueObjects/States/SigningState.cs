using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States;

public sealed class SigningState
{
    public SigningState(SigningStage[] stages, SigningStatus status, UtcDateTime<SigningState> statusChangedAt)
    {
        Stages = stages;
        Status = status;
        StatusChangedAt = statusChangedAt;
    }

    public SigningStage[] Stages { get; }
    public SigningStatus Status { get; private set; }
    public UtcDateTime<SigningState> StatusChangedAt { get; private set; }

    public void SetStatus(SigningStatus status)
    {
        Status = status;
        StatusChangedAt = UtcDateTime<SigningState>.Now;
    }
}
