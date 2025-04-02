using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.AddParticipant;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.AddParticipant.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Delegate;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Delegate.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.TakeInWork;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.TakeInWork.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers.Workflows.Approval;

[Route("documents/workflows/approval/actions/[Action]")]
[ApiController]
[Authorize]
public class DocumentsWorkflowsApprovalActionsController(
    UsersService usersService,
    AddParticipantDocumentWorkflowApprovalActionService addParticipantService,
    CompleteDocumentWorkflowApprovalActionService completeService,
    DelegateDocumentWorkflowApprovalActionService delegateService,
    TakeInWorkDocumentWorkflowApprovalActionService takeInWorkService) : ControllerBase
{
    [HttpPost]
    public async Task<AddParticipantDocumentWorkflowApprovalActionCommandBffResponse> AddParticipant(
        AddParticipantDocumentWorkflowApprovalActionCommandBff query,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await addParticipantService.AddParticipant(query, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<CompleteDocumentWorkflowApprovalActionCommandBffResponse> Complete(
        CompleteDocumentWorkflowApprovalActionCommandBff query,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await completeService.Complete(query, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<DelegateDocumentWorkflowApprovalActionCommandBffResponse> Delegate(
        DelegateDocumentWorkflowApprovalActionCommandBff query,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await delegateService.Delegate(query, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<TakeInWorkDocumentWorkflowApprovalActionCommandBffResponse> TakeInWork(
        TakeInWorkDocumentWorkflowApprovalActionCommandBff query,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await takeInWorkService.TakeInWork(query, user, cancellationToken);

        return result;
    }
}
