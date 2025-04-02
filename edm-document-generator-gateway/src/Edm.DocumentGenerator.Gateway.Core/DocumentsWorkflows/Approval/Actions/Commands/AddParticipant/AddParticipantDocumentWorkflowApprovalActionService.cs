using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.AddParticipant.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.AddParticipant;

public sealed class AddParticipantDocumentWorkflowApprovalActionService : DocumentWorkflowApprovalActionService
{
    public AddParticipantDocumentWorkflowApprovalActionService(IEntitiesApprovalWorkflowsActionsClient approvalActions) : base(approvalActions)
    {
    }

    public async Task<AddParticipantDocumentWorkflowApprovalActionCommandBffResponse> AddParticipant(
        AddParticipantDocumentWorkflowApprovalActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request =
            AddParticipantDocumentWorkflowApprovalActionCommandBffConverter.ToExternal(command, user);

        var actionTask = ApprovalActions.AddParticipant(request, cancellationToken);

        await actionTask;

        return new AddParticipantDocumentWorkflowApprovalActionCommandBffResponse();
    }
}
