using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.Kinds;

internal static class EntitiesApprovalWorkflowAssignmentAutoDelegationKindConverter
{
    internal static EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto FromInternal(
        EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal? kind)
    {
        return kind switch
        {
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal.Executor => EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Executor,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal.Approval => EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Approval,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal.Chief => EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Chief,
            null => EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.None,
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, "Unknown enum value for EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal")
        };
    }
}
