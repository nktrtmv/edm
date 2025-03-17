using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    CompletionReasons;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    DelegationDetails;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails;

internal static class EntitiesApprovalWorkflowAssignmentCompletionDetailsDtoConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionDetailsDto FromInternal(ApprovalWorkflowAssignmentCompletionDetailsInternal details)
    {
        EntitiesApprovalWorkflowAssignmentCompletionReasonDto completionReason =
            EntitiesApprovalWorkflowAssignmentCompletionReasonDtoConverter.FromInternal(details.CompletionReason);

        var completedDate = UtcDateTimeConverterTo.ToTimeStamp(details.CompletedDate);

        EntitiesApprovalWorkflowAssignmentDelegationDetailsDto? delegationDetails =
            NullableConverter.Convert(details.DelegationDetails, EntitiesApprovalWorkflowAssignmentDelegationDetailsDtoConverter.FromInternal);

        var result = new EntitiesApprovalWorkflowAssignmentCompletionDetailsDto
        {
            CompletionReason = completionReason,
            CompletedDate = completedDate,
            CompletionComment = details.CompletionComment,
            DelegationDetails = delegationDetails
        };

        return result;
    }
}
