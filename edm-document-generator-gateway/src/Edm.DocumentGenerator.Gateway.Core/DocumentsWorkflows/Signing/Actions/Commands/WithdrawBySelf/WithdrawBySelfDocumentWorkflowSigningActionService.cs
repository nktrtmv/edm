using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawBySelf.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawBySelf;

public sealed class WithdrawBySelfDocumentWorkflowSigningActionService : DocumentWorkflowSigningActionService
{
    public WithdrawBySelfDocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions)
        : base(actions)
    {
    }

    public async Task<WithdrawBySelfDocumentWorkflowSigningActionCommandBffResponse> WithdrawBySelf(
        WithdrawBySelfDocumentWorkflowSigningActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var context = new SigningWorkflowActionContextExternal(command.WorkflowId, user.Id, user.IsAdmin);

        await Actions.WithdrawBySelf(context, command.Comment, cancellationToken);

        var result = new WithdrawBySelfDocumentWorkflowSigningActionCommandBffResponse();

        return result;
    }
}
