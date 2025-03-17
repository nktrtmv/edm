using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Markers;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;

public sealed record EntitiesApprovalWorkflowExternal(
    Id<EntitiesApprovalWorkflowExternal> Id,
    EntitiesApprovalWorkflowStageExternal[] Stages,
    ApprovalRuleKeyExternal? ApprovalRuleKey,
    UtcDateTime<EntitiesApprovalWorkflowExternal> UpdatedAt,
    UtcDateTime<ApprovalRouteExternal>? RouteUpdatedDate,
    int Status);
