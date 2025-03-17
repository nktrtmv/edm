using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Completers.Workflow.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Completers.Workflow.Stage;

internal static class ApprovalWorkflowStageCompleter
{
    internal static void Complete(ApprovalWorkflowStage stage, ApprovalWorkflowStageStatus status)
    {
        stage.SetStatus(status);

        ApprovalWorkflowGroup[] completingGroups = stage.Groups
            .Where(g => g.Status is not ApprovalWorkflowGroupStatus.Completed)
            .ToArray();

        foreach (ApprovalWorkflowGroup group in completingGroups)
        {
            ApprovalWorkflowGroupCompleter.CompleteAutomatically(group);
        }
    }
}
