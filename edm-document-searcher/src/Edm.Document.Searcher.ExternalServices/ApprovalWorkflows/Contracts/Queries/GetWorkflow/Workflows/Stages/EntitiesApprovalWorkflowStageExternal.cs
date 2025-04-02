using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Statuses;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages;

public sealed record EntitiesApprovalWorkflowStageExternal(
    Id<EntitiesApprovalWorkflowStageExternal> Id,
    EntitiesApprovalWorkflowStageStatusExternal Status,
    UtcDateTime<EntitiesApprovalWorkflowStageExternal>? StartedDate,
    EntitiesApprovalWorkflowGroupExternal[] Groups);
