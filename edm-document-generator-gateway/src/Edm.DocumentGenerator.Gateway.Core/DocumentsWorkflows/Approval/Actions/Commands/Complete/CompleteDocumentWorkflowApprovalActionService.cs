using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete;

public sealed class CompleteDocumentWorkflowApprovalActionService : DocumentWorkflowApprovalActionService
{
    public CompleteDocumentWorkflowApprovalActionService(IEntitiesApprovalWorkflowsActionsClient approvalActions) : base(approvalActions)
    {
    }

    public async Task<CompleteDocumentWorkflowApprovalActionCommandBffResponse> Complete(
        CompleteDocumentWorkflowApprovalActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request = CompleteDocumentWorkflowApprovalActionCommandBffConverter.ToExternal(command, user);

        var actionTask = ApprovalActions.Complete(request, cancellationToken);

        await actionTask;

        return new CompleteDocumentWorkflowApprovalActionCommandBffResponse();
    }
}
