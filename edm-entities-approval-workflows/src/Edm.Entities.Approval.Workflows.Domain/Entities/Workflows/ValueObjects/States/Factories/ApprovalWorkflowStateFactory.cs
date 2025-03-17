using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.Factories;

public static class ApprovalWorkflowStateFactory
{
    public static ApprovalWorkflowState CreateNew(ApprovalWorkflowStage[] stages, Id<Employee>[] ownersIds, Id<Employee>? documentAuthorId)
    {
        var result = new ApprovalWorkflowState(stages, ApprovalWorkflowStatus.InProgress, ownersIds, documentAuthorId, null, false);

        return result;
    }

    public static ApprovalWorkflowState CreateFrom(ApprovalWorkflowState state, bool isLocked)
    {
        ApprovalWorkflowState result = CreateFromDb(
            state.Stages,
            state.Status,
            state.OwnersIds,
            state.DocumentAuthorId,
            state.ActualizedDate,
            isLocked);

        return result;
    }

    public static ApprovalWorkflowState CreateFromDb(
        ApprovalWorkflowStage[] stages,
        ApprovalWorkflowStatus status,
        Id<Employee>[] ownersIds,
        Id<Employee>? documentAuthorId,
        UtcDateTime<ApprovalWorkflowState>? actualizedDate,
        bool isLocked)
    {
        var result = new ApprovalWorkflowState(stages, status, ownersIds, documentAuthorId, actualizedDate, isLocked);

        return result;
    }
}
