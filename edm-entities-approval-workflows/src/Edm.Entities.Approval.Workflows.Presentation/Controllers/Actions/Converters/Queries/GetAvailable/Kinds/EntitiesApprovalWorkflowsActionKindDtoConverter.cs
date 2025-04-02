using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts.Kinds;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailable.Kinds;

internal static class EntitiesApprovalWorkflowsActionKindDtoConverter
{
    internal static EntitiesApprovalWorkflowsActionKindDto FromInternal(ApprovalWorkflowsActionKindInternal action)
    {
        EntitiesApprovalWorkflowsActionKindDto result = action switch
        {
            ApprovalWorkflowsActionKindInternal.Approve
                => EntitiesApprovalWorkflowsActionKindDto.Approve,

            ApprovalWorkflowsActionKindInternal.ApproveWithRemark
                => EntitiesApprovalWorkflowsActionKindDto.ApproveWithRemark,

            ApprovalWorkflowsActionKindInternal.ReturnToRework
                => EntitiesApprovalWorkflowsActionKindDto.ReturnToRework,

            ApprovalWorkflowsActionKindInternal.Reject
                => EntitiesApprovalWorkflowsActionKindDto.Reject,

            ApprovalWorkflowsActionKindInternal.Delegate
                => EntitiesApprovalWorkflowsActionKindDto.Delegate,

            ApprovalWorkflowsActionKindInternal.AddParticipant
                => EntitiesApprovalWorkflowsActionKindDto.AddParticipant,

            ApprovalWorkflowsActionKindInternal.TakeInWork =>
                EntitiesApprovalWorkflowsActionKindDto.TakeInWork,

            _ => throw new ArgumentTypeOutOfRangeException(action)
        };

        return result;
    }
}
