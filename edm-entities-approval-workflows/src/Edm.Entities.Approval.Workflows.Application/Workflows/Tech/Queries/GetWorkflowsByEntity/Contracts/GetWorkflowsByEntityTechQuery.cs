using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Queries.GetWorkflowsByEntity.Contracts;

public sealed record GetWorkflowsByEntityTechQuery(string EntityId): IRequest<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow[]>;
