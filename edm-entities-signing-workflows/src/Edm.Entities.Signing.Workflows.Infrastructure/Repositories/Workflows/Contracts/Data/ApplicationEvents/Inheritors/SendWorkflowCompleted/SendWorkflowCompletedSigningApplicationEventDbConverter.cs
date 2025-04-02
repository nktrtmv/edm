using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.States.Statuses;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.Inheritors.SendWorkflowCompleted;

internal static class SendWorkflowCompletedSigningApplicationEventDbConverter
{
    internal static SendWorkflowCompletedSigningApplicationEventDb FromDomain(SendWorkflowCompletedSigningApplicationEvent applicationEvent)
    {
        SigningStageStatusDb lastFinishedStageStatus =
            SigningStageStatusDbConverter.FromDomain(applicationEvent.LastFinishedStageStatus);

        var currentUserId = IdConverterTo.ToString(applicationEvent.CurrentUserId);

        var result = new SendWorkflowCompletedSigningApplicationEventDb
        {
            LastFinishedStageStatus = lastFinishedStageStatus,
            CurrentUserId = currentUserId
        };

        return result;
    }

    internal static SendWorkflowCompletedSigningApplicationEvent ToDomain(SendWorkflowCompletedSigningApplicationEventDb applicationEvent)
    {
        SigningStageStatus lastFinishedStageStatus = SigningStageStatusDbConverter.ToDomain(applicationEvent.LastFinishedStageStatus);

        Id<User> currentUserId = string.IsNullOrWhiteSpace(applicationEvent.CurrentUserId)
            ? Id<User>.Empty01
            : IdConverterFrom<User>.FromString(applicationEvent.CurrentUserId);

        SendWorkflowCompletedSigningApplicationEvent result =
            SendWorkflowCompletedSigningApplicationEventFactory.CreateFromDb(lastFinishedStageStatus, currentUserId);

        return result;
    }
}
