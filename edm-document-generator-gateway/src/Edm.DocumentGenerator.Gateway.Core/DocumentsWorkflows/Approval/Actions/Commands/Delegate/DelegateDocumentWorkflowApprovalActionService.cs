using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Delegate.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Delegate;

public sealed class DelegateDocumentWorkflowApprovalActionService : DocumentWorkflowApprovalActionService
{
    public DelegateDocumentWorkflowApprovalActionService(IEntitiesApprovalWorkflowsActionsClient approvalActions) : base(approvalActions)
    {
    }

    public async Task<DelegateDocumentWorkflowApprovalActionCommandBffResponse> Delegate(
        DelegateDocumentWorkflowApprovalActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request = DelegateDocumentWorkflowApprovalActionCommandBffConverter.ToExternal(command, user);

        var actionTask = ApprovalActions.Delegate(request, cancellationToken);

        await actionTask;

        return new DelegateDocumentWorkflowApprovalActionCommandBffResponse();
    }
}
