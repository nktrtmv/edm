using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Queries.GetAvailable.Actions.Kinds;

internal static class EntitiesApprovalWorkflowActionKindExternalConverter
{
    internal static EntitiesApprovalWorkflowActionKindExternal FromDto(EntitiesApprovalWorkflowsActionKindDto action)
    {
        var result = action switch
        {
            EntitiesApprovalWorkflowsActionKindDto.Approve => EntitiesApprovalWorkflowActionKindExternal.Approve,
            EntitiesApprovalWorkflowsActionKindDto.ApproveWithRemark => EntitiesApprovalWorkflowActionKindExternal.ApproveWithRemark,
            EntitiesApprovalWorkflowsActionKindDto.ReturnToRework => EntitiesApprovalWorkflowActionKindExternal.ReturnToRework,
            EntitiesApprovalWorkflowsActionKindDto.Reject => EntitiesApprovalWorkflowActionKindExternal.Reject,
            EntitiesApprovalWorkflowsActionKindDto.Delegate => EntitiesApprovalWorkflowActionKindExternal.Delegate,
            EntitiesApprovalWorkflowsActionKindDto.TakeInWork => EntitiesApprovalWorkflowActionKindExternal.TakeInWork,
            EntitiesApprovalWorkflowsActionKindDto.AddParticipant => EntitiesApprovalWorkflowActionKindExternal.AddParticipant,
            _ => throw new ArgumentTypeOutOfRangeException(action)
        };

        return result;
    }
}
