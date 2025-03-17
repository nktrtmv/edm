using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Commands.DeleteWorkflows;

public sealed record DeleteWorkflowsCommandInternal(string DomainId, string[] EntitiesIds) : IRequest;
