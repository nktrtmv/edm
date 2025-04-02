using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;

public sealed class ApprovalWorkflowState(
    ApprovalWorkflowStage[] stages,
    ApprovalWorkflowStatus status,
    Id<Employee>[] ownersIds,
    Id<Employee>? documentAuthorId,
    UtcDateTime<ApprovalWorkflowState>? actualizedDate,
    bool isLocked)
{
    public ApprovalWorkflowStage[] Stages { get; private set; } = stages;
    public ApprovalWorkflowStatus Status { get; private set; } = status;
    public Id<Employee>[] OwnersIds { get; private set; } = ownersIds;
    public Id<Employee>? DocumentAuthorId { get; private set; } = documentAuthorId;
    public UtcDateTime<ApprovalWorkflowState>? ActualizedDate { get; private set; } = actualizedDate;
    public bool IsLocked { get; } = isLocked;

    public bool IsCompleted => Status is
        ApprovalWorkflowStatus.Approved or
        ApprovalWorkflowStatus.Rejected or
        ApprovalWorkflowStatus.ApprovedWithRemark or
        ApprovalWorkflowStatus.ReturnedToRework;

    public void SetStages(ApprovalWorkflowStage[] stages)
    {
        Stages = stages;
    }

    public void SetStatus(ApprovalWorkflowStatus status)
    {
        Status = status;
    }

    public void SetDocumentAuthorId(Id<Employee> documentAuthorId)
    {
        DocumentAuthorId = documentAuthorId;
    }

    internal void SetOwnersIds(Id<Employee>[] ownersIds)
    {
        OwnersIds = ownersIds;
    }

    public void SetActualizedDate(UtcDateTime<ApprovalWorkflowState> lastActualizedDate)
    {
        ActualizedDate = lastActualizedDate;
    }
}
