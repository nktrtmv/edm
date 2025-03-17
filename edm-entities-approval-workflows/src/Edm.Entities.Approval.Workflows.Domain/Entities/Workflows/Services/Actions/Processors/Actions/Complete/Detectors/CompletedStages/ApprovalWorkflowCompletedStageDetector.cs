using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Detectors.CompletedStages;

internal static class ApprovalWorkflowCompletedStageDetector
{
    internal static bool Detect(ApprovalWorkflowStage stage)
    {
        bool result = stage.Type switch
        {
            ApprovalWorkflowStageType.Sequential => stage.Groups.All(GroupIsCompleted),
            ApprovalWorkflowStageType.ParallelAll => stage.Groups.All(GroupIsCompleted),
            ApprovalWorkflowStageType.ParallelAny => stage.Groups.Any(GroupIsCompleted),
            _ => throw new ArgumentTypeOutOfRangeException(stage.Type)
        };

        return result;
    }

    private static bool GroupIsCompleted(ApprovalWorkflowGroup group)
    {
        bool result = group.Status == ApprovalWorkflowGroupStatus.Completed;

        return result;
    }
}
