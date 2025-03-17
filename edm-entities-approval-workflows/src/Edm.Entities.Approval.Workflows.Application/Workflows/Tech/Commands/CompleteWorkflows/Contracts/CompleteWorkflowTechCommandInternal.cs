using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Commands.CompleteWorkflows.Contracts;

public sealed record CompleteWorkflowTechCommandInternal(string WorkflowId, ApprovalWorkflowStatus CompleteStatus) : IRequest;
