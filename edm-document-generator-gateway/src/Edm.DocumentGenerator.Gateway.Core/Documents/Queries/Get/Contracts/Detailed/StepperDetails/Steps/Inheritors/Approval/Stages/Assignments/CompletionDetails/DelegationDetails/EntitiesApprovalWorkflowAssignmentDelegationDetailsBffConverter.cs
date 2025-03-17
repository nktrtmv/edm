using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails.AutoDelegationKinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.DelegationDetails;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails;

internal static class EntitiesApprovalWorkflowAssignmentDelegationDetailsBffConverter
{
    internal static EntitiesApprovalWorkflowAssignmentDelegationDetailsBff FromDomain(EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal details)
    {
        var delegatedToId = IdConverterTo.ToString(details.DelegatedToId);

        var autoDelegationKind =
            NullableConverter.Convert(details.AutoDelegationKind, EntitiesApprovalWorkflowAssignmentAutoDelegationKindBffConverter.FromExternal);

        var result = new EntitiesApprovalWorkflowAssignmentDelegationDetailsBff(delegatedToId, autoDelegationKind);

        return result;
    }
}
