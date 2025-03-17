using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.DelegationDetails;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.Kinds;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

internal static class EntitiesApprovalWorkflowAssignmentDelegationDetailsConverter
{
    internal static EntitiesApprovalWorkflowAssignmentDelegationDetailsDto FromInternal(
        EntitiesApprovalWorkflowAssignmentDelegationDetailsInternal delegationDetails)
    {
        var autoDelegationKind = EntitiesApprovalWorkflowAssignmentAutoDelegationKindConverter.FromInternal(delegationDetails.AutoDelegationKind);

        var result = new EntitiesApprovalWorkflowAssignmentDelegationDetailsDto
        {
            DelegatedToId = delegationDetails.DelegatedToId,
            AutoDelegationKind = autoDelegationKind
        };

        return result;
    }
}
