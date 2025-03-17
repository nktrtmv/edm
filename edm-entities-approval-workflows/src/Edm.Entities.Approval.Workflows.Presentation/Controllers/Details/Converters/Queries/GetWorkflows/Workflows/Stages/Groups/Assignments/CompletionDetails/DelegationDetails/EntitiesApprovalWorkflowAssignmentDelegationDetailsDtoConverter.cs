using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    DelegationDetails.Kinds;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.DelegationDetails;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    DelegationDetails;

internal static class EntitiesApprovalWorkflowAssignmentDelegationDetailsDtoConverter
{
    internal static EntitiesApprovalWorkflowAssignmentDelegationDetailsDto FromInternal(ApprovalWorkflowAssignmentDelegationDetailsInternal details)
    {
        var delegatedToId = IdConverterTo.ToString(details.DelegatedToId);

        var result = new EntitiesApprovalWorkflowAssignmentDelegationDetailsDto
        {
            DelegatedToId = delegatedToId
        };

        if (details.AutoDelegationKind is not null)
        {
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto autoDelegationKind =
                EntitiesApprovalWorkflowAssignmentAutoDelegationKindDtoConverter.FromInternal(details.AutoDelegationKind.Value);

            result.AutoDelegationKind = autoDelegationKind;
        }

        return result;
    }
}
