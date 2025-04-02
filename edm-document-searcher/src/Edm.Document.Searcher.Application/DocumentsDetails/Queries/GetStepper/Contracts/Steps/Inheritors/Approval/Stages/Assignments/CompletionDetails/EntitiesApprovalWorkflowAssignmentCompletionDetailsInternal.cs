using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.CompletionReasons;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.DelegationDetails;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.
    CompletionDetails;

public sealed record EntitiesApprovalWorkflowAssignmentCompletionDetailsInternal(
    EntitiesApprovalWorkflowAssignmentCompletionReasonInternal CompletionReason,
    DateTime CompletedDate,
    string? CompletionComment,
    EntitiesApprovalWorkflowAssignmentDelegationDetailsInternal? DelegationDetails);
