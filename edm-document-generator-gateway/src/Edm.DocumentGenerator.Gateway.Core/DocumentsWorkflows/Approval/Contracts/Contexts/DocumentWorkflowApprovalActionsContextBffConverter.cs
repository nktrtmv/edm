using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

internal static class DocumentWorkflowApprovalActionsContextBffConverter
{
    internal static EntitiesApprovalWorkflowActionContextExternal ToExternal(DocumentWorkflowApprovalActionsContextBff context, UserBff user)
    {
        var result = new EntitiesApprovalWorkflowActionContextExternal(context.WorkflowId, context.StageId, user.Id);

        return result;
    }
}
