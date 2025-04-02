using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.
    CompletionDetails;

public sealed class EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal(
    EntitiesApprovalWorkflowAssignmentCompletionReasonExternal completionReason,
    UtcDateTime<EntitiesApprovalWorkflowAssignmentExternal> completedDate,
    string? completionComment,
    EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal? delegationDetails)
{
    public EntitiesApprovalWorkflowAssignmentCompletionReasonExternal CompletionReason { get; } = completionReason;
    public UtcDateTime<EntitiesApprovalWorkflowAssignmentExternal> CompletedDate { get; } = completedDate;
    public string? CompletionComment { get; } = completionComment;
    public EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal? DelegationDetails { get; private set; } = delegationDetails;
}
