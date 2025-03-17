using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Info;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Options;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;

public sealed record ApprovalParametersInternal(
    ApprovalEntityInternal Entity,
    ApprovalInfoInternal Info,
    ApprovalOptionsInternal Options,
    ApprovalRuleKeyInternal ApprovalRuleKey,
    Id<EmployeeInternal> OwnerId,
    Id<EmployeeInternal>? DocumentAuthorId,
    UtcDateTime<ApprovalRouteInternal>? RouteUpdatedDate);
