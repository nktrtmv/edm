using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawByContractor.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawByContractor;

public sealed class WithdrawByContractorDocumentWorkflowSigningActionService : DocumentWorkflowSigningActionService
{
    public WithdrawByContractorDocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions)
        : base(actions)
    {
    }

    public async Task<WithdrawByContractorDocumentWorkflowSigningActionCommandBffResponse> WithdrawByContractor(
        WithdrawByContractorDocumentWorkflowSigningActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var context = new SigningWorkflowActionContextExternal(command.WorkflowId, user.Id, user.IsAdmin);

        await Actions.WithdrawByContractor(context, command.Comment, cancellationToken);

        var result = new WithdrawByContractorDocumentWorkflowSigningActionCommandBffResponse();

        return result;
    }
}
