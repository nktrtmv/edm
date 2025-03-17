using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.CompletionReasons;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.DelegationDetails;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails;

internal static class EntitiesApprovalWorkflowAssignmentCompletionDetailsInternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionDetailsInternal FromExternal(EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal details)
    {
        EntitiesApprovalWorkflowAssignmentCompletionReasonInternal completionReason =
            EntitiesApprovalWorkflowAssignmentCompletionReasonInternalConverter.FromExternal(details.CompletionReason);

        var completedDate = UtcDateTimeConverterTo.ToDateTime(details.CompletedDate);

        EntitiesApprovalWorkflowAssignmentDelegationDetailsInternal? delegationDetails =
            NullableConverter.Convert(details.DelegationDetails, EntitiesApprovalWorkflowAssignmentDelegationDetailsInternalConverter.FromDomain);

        var result = new EntitiesApprovalWorkflowAssignmentCompletionDetailsInternal(
            completionReason,
            completedDate,
            details.CompletionComment,
            delegationDetails);

        return result;
    }
}
