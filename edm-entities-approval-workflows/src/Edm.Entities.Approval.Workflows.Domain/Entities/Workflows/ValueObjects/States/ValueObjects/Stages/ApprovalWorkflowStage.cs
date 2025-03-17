using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;

public sealed class ApprovalWorkflowStage
{
    internal ApprovalWorkflowStage(
        Id<ApprovalWorkflowStage> id,
        string name,
        ApprovalWorkflowStageType type,
        ApprovalWorkflowStageStatus status,
        ApprovalWorkflowGroup[] groups,
        UtcDateTime<ApprovalWorkflowStage>? startedDate)
    {
        Id = id;
        Name = name;
        Type = type;
        Status = status;
        Groups = groups;
        StartedDate = startedDate;
    }

    public Id<ApprovalWorkflowStage> Id { get; }
    public string Name { get; }
    public ApprovalWorkflowStageType Type { get; }
    public ApprovalWorkflowStageStatus Status { get; private set; }
    public ApprovalWorkflowGroup[] Groups { get; private set; }
    public UtcDateTime<ApprovalWorkflowStage>? StartedDate { get; private set; }

    public bool IsCompleted => Status is
        ApprovalWorkflowStageStatus.Approved or
        ApprovalWorkflowStageStatus.Rejected or
        ApprovalWorkflowStageStatus.ReturnedToRework or
        ApprovalWorkflowStageStatus.ApprovedWithRemark;

    public void SetStatus(ApprovalWorkflowStageStatus status)
    {
        Status = status;
    }

    public void SetStartedDate(UtcDateTime<ApprovalWorkflowStage> startedDate)
    {
        StartedDate = startedDate;
    }

    public void SetGroups(ApprovalWorkflowGroup[] groups)
    {
        Groups = groups;
    }

    public override string ToString()
    {
        string groups = string.Join<ApprovalWorkflowGroup>(", ", Groups);

        return $"{{ Id: {Id}, Type: {Type}, Status: {Status}, Groups: [{groups}] }}";
    }
}
