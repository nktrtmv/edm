using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.CompletionReasons;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.DelegationDetails;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails;

internal static class EntitiesApprovalWorkflowAssignmentCompletionDetailsExternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal FromDto(EntitiesApprovalWorkflowAssignmentCompletionDetailsDto details)
    {
        var completionReason =
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternalConverter.FromDto(details.CompletionReason);

        UtcDateTime<EntitiesApprovalWorkflowAssignmentExternal> completedDate =
            UtcDateTimeConverterFrom<EntitiesApprovalWorkflowAssignmentExternal>.FromTimestamp(details.CompletedDate);

        var delegationDetails =
            NullableConverter.Convert(details.DelegationDetails, EntitiesApprovalWorkflowAssignmentDelegationDetailsExternalConverter.FromDto);

        var result = new EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal(
            completionReason,
            completedDate,
            details.CompletionComment,
            delegationDetails);

        return result;
    }
}
