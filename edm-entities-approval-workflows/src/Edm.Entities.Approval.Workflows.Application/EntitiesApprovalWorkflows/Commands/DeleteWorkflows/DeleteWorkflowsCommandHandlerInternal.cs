using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Repositories.Workflows;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Commands.DeleteWorkflows;

public sealed class DeleteWorkflowsCommandHandlerInternal(IApprovalWorkflowsRepository approvalWorkflowsRepository)
    : IRequestHandler<DeleteWorkflowsCommandInternal>
{
    public async Task Handle(DeleteWorkflowsCommandInternal request, CancellationToken cancellationToken)
    {
        var domainId = DomainId.Parse(request.DomainId);
        var entitiesIds = request.EntitiesIds.Select(EntityId.Parse).ToHashSet();

        await approvalWorkflowsRepository.Delete(domainId, entitiesIds, cancellationToken);
    }
}
