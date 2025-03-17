using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.CompletionDetails;

internal static class EntitiesApprovalWorkflowAssignmentCompletionDetailsConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionDetailsDto FromInternal(
        EntitiesApprovalWorkflowAssignmentCompletionDetailsInternal completionDetails)
    {
        var completionReason = EntitiesApprovalWorkflowAssignmentCompletionReasonConverter.FromInternal(completionDetails.CompletionReason);
        var delegationDetails = NullableConverter.Convert(completionDetails.DelegationDetails, EntitiesApprovalWorkflowAssignmentDelegationDetailsConverter.FromInternal);

        var result = new EntitiesApprovalWorkflowAssignmentCompletionDetailsDto
        {
            CompletionReason = completionReason,
            CompletedDate = completionDetails.CompletedDate.ToTimestamp(),
            CompletionComment = completionDetails.CompletionComment,
            DelegationDetails = delegationDetails
        };

        return result;
    }
}
