using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;

public sealed record ApprovalRouteInternal(ApprovalRouteStageInternal[] Stages);
