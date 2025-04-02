using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    CompletionReasons;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails;

internal static class EntitiesApprovalWorkflowAssignmentCompletionDetailsBffConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionDetailsBff FromExternal(EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal details)
    {
        var completionReason =
            EntitiesApprovalWorkflowAssignmentCompletionReasonBffConverter.FromExternal(details.CompletionReason);

        var completedDate = UtcDateTimeConverterTo.ToDateTime(details.CompletedDate);

        var delegationDetails =
            NullableConverter.Convert(details.DelegationDetails, EntitiesApprovalWorkflowAssignmentDelegationDetailsBffConverter.FromDomain);

        var result = new EntitiesApprovalWorkflowAssignmentCompletionDetailsBff(
            completionReason,
            completedDate,
            details.CompletionComment,
            delegationDetails);

        return result;
    }
}
