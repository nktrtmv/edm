using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.TakeInWork.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.TakeInWork;

public sealed class TakeInWorkDocumentWorkflowApprovalActionService : DocumentWorkflowApprovalActionService
{
    public TakeInWorkDocumentWorkflowApprovalActionService(IEntitiesApprovalWorkflowsActionsClient approvalActions) : base(approvalActions)
    {
    }

    public async Task<TakeInWorkDocumentWorkflowApprovalActionCommandBffResponse> TakeInWork(
        TakeInWorkDocumentWorkflowApprovalActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request = TakeInWorkDocumentWorkflowApprovalActionCommandBffConverter.ToExternal(command, user);

        var actionTask = ApprovalActions.TakeInWork(request, cancellationToken);

        await actionTask;

        return new TakeInWorkDocumentWorkflowApprovalActionCommandBffResponse();
    }
}
