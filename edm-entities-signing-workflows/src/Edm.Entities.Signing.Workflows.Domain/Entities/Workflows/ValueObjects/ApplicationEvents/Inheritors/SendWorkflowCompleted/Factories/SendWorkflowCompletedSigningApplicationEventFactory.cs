using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted.Factories.LastFinishedStageStatuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted.Factories;

public static class SendWorkflowCompletedSigningApplicationEventFactory
{
    public static SendWorkflowCompletedSigningApplicationEvent CreateFrom(SigningWorkflow workflow, Id<User> currentUserId)
    {
        SigningStageStatus lastFinishedStageStatus = LastFinishedStageStatusDetector.DetectFrom(workflow);

        var result = new SendWorkflowCompletedSigningApplicationEvent(lastFinishedStageStatus, currentUserId);

        return result;
    }

    public static SendWorkflowCompletedSigningApplicationEvent CreateFromDb(SigningStageStatus lastFinishedStageStatus, Id<User> currentUserId)
    {
        var result = new SendWorkflowCompletedSigningApplicationEvent(lastFinishedStageStatus, currentUserId);

        return result;
    }
}
