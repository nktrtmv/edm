using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails;

public sealed class EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal
{
    public EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal(
        EntitiesApprovalWorkflowAssignmentCompletionReasonExternal completionReason,
        UtcDateTime<EntitiesApprovalWorkflowAssignmentExternal> completedDate,
        string? completionComment,
        EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal? delegationDetails)
    {
        CompletionReason = completionReason;
        CompletedDate = completedDate;
        CompletionComment = completionComment;
        DelegationDetails = delegationDetails;
    }

    public EntitiesApprovalWorkflowAssignmentCompletionReasonExternal CompletionReason { get; }
    public UtcDateTime<EntitiesApprovalWorkflowAssignmentExternal> CompletedDate { get; }
    public string? CompletionComment { get; }
    public EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal? DelegationDetails { get; private set; }
}
