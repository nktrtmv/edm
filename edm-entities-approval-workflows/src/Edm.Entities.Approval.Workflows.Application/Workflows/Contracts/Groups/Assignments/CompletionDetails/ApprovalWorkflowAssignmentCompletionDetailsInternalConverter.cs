using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.DelegationDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.CompletionDetails;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails;

internal static class ApprovalWorkflowAssignmentCompletionDetailsInternalConverter
{
    internal static ApprovalWorkflowAssignmentCompletionDetailsInternal FromDomain(ApprovalWorkflowAssignmentCompletionDetails details)
    {
        ApprovalWorkflowAssignmentCompletionReasonInternal completionReason =
            ApprovalWorkflowAssignmentCompletionReasonInternalConverter.FromDomain(details.CompletionReason);

        UtcDateTime<ApprovalWorkflowAssignmentInternal> completedDate =
            UtcDateTimeConverterFrom<ApprovalWorkflowAssignmentInternal>.From(details.CompletedDate);

        ApprovalWorkflowAssignmentDelegationDetailsInternal? delegationDetails =
            NullableConverter.Convert(details.DelegationDetails, ApprovalWorkflowAssignmentDelegationDetailsInternalConverter.FromDomain);

        var result = new ApprovalWorkflowAssignmentCompletionDetailsInternal(
            completionReason,
            completedDate,
            details.CompletionComment,
            delegationDetails);

        return result;
    }
}
