using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Statuses;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages;

public sealed record ApprovalWorkflowStageInternal(
    Id<ApprovalWorkflowStageInternal> Id,
    string Name,
    ApprovalWorkflowGroupInternal[] Groups,
    ApprovalWorkflowStageStatusInternal Status,
    ApprovalWorkflowStageTypeInternal Type,
    UtcDateTime<ApprovalWorkflowStageInternal>? StartedDate);
