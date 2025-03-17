using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Cancel;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Cancel.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.PutIntoEffect;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.PutIntoEffect.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.ReturnToRework;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.ReturnToRework.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.SendToContractor;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.SendToContractor.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawByContractor;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawByContractor.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawBySelf;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawBySelf.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers.Workflows.Signing;

[Authorize]
[ApiController]
[Route("documents/workflows/signing/actions/[Action]")]
public class DocumentsWorkflowsSigningActionsController(
    UsersService users,
    GetDocumentsToSignDocumentWorkflowSigningActionService getDocumentsToSignService,
    CancelDocumentWorkflowSigningActionService cancelService,
    PutIntoEffectDocumentWorkflowSigningActionService putIntoEffectService,
    ReturnToReworkDocumentWorkflowSigningActionService returnToReworkService,
    SendToContractorDocumentWorkflowSigningActionService sendToContractorService,
    SignDocumentWorkflowSigningActionService signService,
    WithdrawByContractorDocumentWorkflowSigningActionService withdrawByContractorService,
    WithdrawBySelfDocumentWorkflowSigningActionService withdrawBySelfService)
    : ControllerBase
{
    [HttpPost]
    public async Task<GetDocumentsToSignDocumentWorkflowSigningActionQueryBffResponse> GetDocumentsToSign(
        GetDocumentsToSignDocumentWorkflowSigningActionQueryBff query,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await getDocumentsToSignService.GetDocumentsToSign(query, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<CancelDocumentWorkflowSigningActionCommandBffResponse> Cancel(
        CancelDocumentWorkflowSigningActionCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await cancelService.Cancel(command, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<PutIntoEffectDocumentWorkflowSigningActionCommandBffResponse> PutIntoEffect(
        PutIntoEffectDocumentWorkflowSigningActionCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await putIntoEffectService.PutIntoEffect(command, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<ReturnToReworkDocumentWorkflowSigningActionCommandBffResponse> ReturnToRework(
        ReturnToReworkDocumentWorkflowSigningActionCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await returnToReworkService.ReturnToRework(command, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<SendToContractorDocumentWorkflowSigningActionCommandBffResponse> SendToContractor(
        SendToContractorDocumentWorkflowSigningActionCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await sendToContractorService.SendToContractor(command, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<SignDocumentWorkflowSigningActionCommandBffResponse> Sign(
        SignDocumentWorkflowSigningActionCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await signService.Sign(command, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<WithdrawByContractorDocumentWorkflowSigningActionCommandBffResponse> WithdrawByContractor(
        WithdrawByContractorDocumentWorkflowSigningActionCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await withdrawByContractorService.WithdrawByContractor(command, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<WithdrawBySelfDocumentWorkflowSigningActionCommandBffResponse> WithdrawBySelf(
        WithdrawBySelfDocumentWorkflowSigningActionCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await withdrawBySelfService.WithdrawBySelf(command, user, cancellationToken);

        return result;
    }
}
