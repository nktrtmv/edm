using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Grpc.Core;

using MediatR;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Commands.DeleteWorkflows;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers;

internal sealed class EntitiesApprovalWorkflowsController(IMediator mediator) : EntitiesApprovalWorkflowsService.EntitiesApprovalWorkflowsServiceBase
{
    public override async Task<DeleteWorkflowsByEntitiesIdsCommandResponse> DeleteWorkflowsByEntitiesIds(
        DeleteWorkflowsByEntitiesIdsCommand request,
        ServerCallContext context)
    {
        var command = new DeleteWorkflowsCommandInternal(request.DomainId, request.EntitiesIds.ToArray());

        await mediator.Send(command, context.CancellationToken);

        return new DeleteWorkflowsByEntitiesIdsCommandResponse();
    }
}
