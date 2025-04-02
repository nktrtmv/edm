using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    CompletionReasons;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.
    CompletionDetails;

public sealed class EntitiesApprovalWorkflowAssignmentCompletionDetailsBff
{
    public EntitiesApprovalWorkflowAssignmentCompletionDetailsBff(
        EntitiesApprovalWorkflowAssignmentCompletionReasonBff completionReason,
        DateTime completedDate,
        string? completionComment,
        EntitiesApprovalWorkflowAssignmentDelegationDetailsBff? delegationDetails)
    {
        CompletionReason = completionReason;
        CompletedDate = completedDate;
        CompletionComment = completionComment;
        DelegationDetails = delegationDetails;
    }

    public EntitiesApprovalWorkflowAssignmentCompletionReasonBff CompletionReason { get; }
    public DateTime CompletedDate { get; }
    public string? CompletionComment { get; }
    public EntitiesApprovalWorkflowAssignmentDelegationDetailsBff? DelegationDetails { get; }
}
