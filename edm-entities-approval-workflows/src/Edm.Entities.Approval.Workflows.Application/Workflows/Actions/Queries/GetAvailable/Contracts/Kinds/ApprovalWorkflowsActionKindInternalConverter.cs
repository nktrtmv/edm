using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts.Kinds;

internal static class ApprovalWorkflowsActionKindInternalConverter
{
    internal static ApprovalWorkflowsActionKindInternal FromDomain(ApprovalWorkflowActionKind workflowAction)
    {
        ApprovalWorkflowsActionKindInternal result = workflowAction switch
        {
            ApprovalWorkflowActionKind.Approve
                => ApprovalWorkflowsActionKindInternal.Approve,

            ApprovalWorkflowActionKind.ApproveWithRemark
                => ApprovalWorkflowsActionKindInternal.ApproveWithRemark,

            ApprovalWorkflowActionKind.ReturnToRework
                => ApprovalWorkflowsActionKindInternal.ReturnToRework,

            ApprovalWorkflowActionKind.Reject
                => ApprovalWorkflowsActionKindInternal.Reject,

            ApprovalWorkflowActionKind.Delegate
                => ApprovalWorkflowsActionKindInternal.Delegate,

            ApprovalWorkflowActionKind.AddParticipant
                => ApprovalWorkflowsActionKindInternal.AddParticipant,

            ApprovalWorkflowActionKind.TakeInWork =>
                ApprovalWorkflowsActionKindInternal.TakeInWork,

            _ => throw new ArgumentTypeOutOfRangeException(workflowAction)
        };

        return result;
    }
}
