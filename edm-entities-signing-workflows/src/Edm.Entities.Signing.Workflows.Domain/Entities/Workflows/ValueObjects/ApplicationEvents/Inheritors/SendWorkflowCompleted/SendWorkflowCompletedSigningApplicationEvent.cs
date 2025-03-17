using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted;

public sealed class SendWorkflowCompletedSigningApplicationEvent : SigningApplicationEvent
{
    internal SendWorkflowCompletedSigningApplicationEvent(SigningStageStatus lastFinishedStageStatus, Id<User> currentUserId)
    {
        LastFinishedStageStatus = lastFinishedStageStatus;
        CurrentUserId = currentUserId;
    }

    public SigningStageStatus LastFinishedStageStatus { get; }
    public Id<User> CurrentUserId { get; }
}
