using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.Factories;

public static class ApprovalWorkflowStageFactory
{
    public static ApprovalWorkflowStage CreateNew(Id<ApprovalWorkflowStage> id, string name, ApprovalWorkflowStageType type, ApprovalWorkflowGroup[] groups)
    {
        var result = new ApprovalWorkflowStage(id, name, type, ApprovalWorkflowStageStatus.NotStarted, groups, null);

        return result;
    }

    public static ApprovalWorkflowStage CreateFromDb(
        Id<ApprovalWorkflowStage> id,
        string name,
        ApprovalWorkflowStageType type,
        ApprovalWorkflowStageStatus status,
        ApprovalWorkflowGroup[] groups,
        UtcDateTime<ApprovalWorkflowStage>? startedDate)
    {
        var result = new ApprovalWorkflowStage(id, name, type, status, groups, startedDate);

        return result;
    }
}
