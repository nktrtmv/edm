using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails;

internal static class ApprovalWorkflowAssignmentCompletionDetailsDbConverter
{
    internal static ApprovalWorkflowAssignmentCompletionDetailsDb FromDomain(ApprovalWorkflowAssignmentCompletionDetails details)
    {
        ApprovalWorkflowAssignmentCompletionReasonDb completionReason =
            ApprovalWorkflowAssignmentCompletionReasonDbConverter.FromDomain(details.CompletionReason);

        var completedDate = UtcDateTimeConverterTo.ToTimeStamp(details.CompletedDate);

        ApprovalWorkflowAssignmentDelegationDetailsDb? delegationDetails =
            NullableConverter.Convert(details.DelegationDetails, ApprovalWorkflowAssignmentDelegationDetailsDbConverter.FromDomain);

        var result = new ApprovalWorkflowAssignmentCompletionDetailsDb
        {
            CompletionReason = completionReason,
            CompletedDate = completedDate,
            CompletionComment = details.CompletionComment,
            DelegationDetails = delegationDetails
        };

        return result;
    }

    internal static ApprovalWorkflowAssignmentCompletionDetails ToDomain(ApprovalWorkflowAssignmentCompletionDetailsDb details)
    {
        ApprovalWorkflowAssignmentCompletionReason completionReason =
            ApprovalWorkflowAssignmentCompletionReasonDbConverter.ToDomain(details.CompletionReason);

        UtcDateTime<ApprovalWorkflowAssignment> completedDate =
            UtcDateTimeConverterFrom<ApprovalWorkflowAssignment>.FromTimestamp(details.CompletedDate);

        ApprovalWorkflowAssignmentDelegationDetails? delegationDetails =
            NullableConverter.Convert(details.DelegationDetails, ApprovalWorkflowAssignmentDelegationDetailsDbConverter.ToDomain);

        ApprovalWorkflowAssignmentCompletionDetails result =
            ApprovalWorkflowAssignmentCompletionDetailsFactory.CreateFromDb(
                completionReason,
                completedDate,
                details.CompletionComment,
                delegationDetails);

        return result;
    }
}
