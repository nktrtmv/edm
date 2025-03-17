using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval.Kinds;

internal static class DocumentWorkflowApprovalActionKindBffConverter
{
    internal static DocumentWorkflowApprovalActionKindBff FromExternal(EntitiesApprovalWorkflowActionKindExternal kind)
    {
        var result = kind switch
        {
            EntitiesApprovalWorkflowActionKindExternal.Approve => DocumentWorkflowApprovalActionKindBff.Approve,
            EntitiesApprovalWorkflowActionKindExternal.ApproveWithRemark => DocumentWorkflowApprovalActionKindBff.ApproveWithRemark,
            EntitiesApprovalWorkflowActionKindExternal.ReturnToRework => DocumentWorkflowApprovalActionKindBff.ReturnToRework,
            EntitiesApprovalWorkflowActionKindExternal.Reject => DocumentWorkflowApprovalActionKindBff.Reject,
            EntitiesApprovalWorkflowActionKindExternal.Delegate => DocumentWorkflowApprovalActionKindBff.Delegate,
            EntitiesApprovalWorkflowActionKindExternal.TakeInWork => DocumentWorkflowApprovalActionKindBff.TakeInWork,
            EntitiesApprovalWorkflowActionKindExternal.AddParticipant => DocumentWorkflowApprovalActionKindBff.AddParticipant,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
