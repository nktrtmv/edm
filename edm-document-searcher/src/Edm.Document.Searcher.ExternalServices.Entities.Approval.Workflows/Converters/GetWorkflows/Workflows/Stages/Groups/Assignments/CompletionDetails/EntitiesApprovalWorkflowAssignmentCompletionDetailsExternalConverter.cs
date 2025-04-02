using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails;

public static class EntitiesApprovalWorkflowAssignmentCompletionDetailsExternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal? FromDto(EntitiesApprovalWorkflowAssignmentCompletionDetailsDto? completionDetails)
    {
        if (completionDetails is null)
        {
            return null;
        }

        var completionReason = EntitiesApprovalWorkflowAssignmentCompletionReasonExternalConverter.FromDto(completionDetails.CompletionReason);
        var completedDate = UtcDateTimeConverterFrom<EntitiesApprovalWorkflowAssignmentExternal>.FromTimestamp(completionDetails.CompletedDate);
        var delegationDetails = EntitiesApprovalWorkflowAssignmentDelegationDetailsExternalConverter.FromDto(completionDetails.DelegationDetails);

        var result = new EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal(
            completionReason,
            completedDate,
            completionDetails.CompletionComment,
            delegationDetails);

        return result;
    }
}
