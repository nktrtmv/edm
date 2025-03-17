using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;

public static class EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal? FromDto(EntitiesApprovalWorkflowAssignmentDelegationDetailsDto delegationDetails)
    {
        if (!delegationDetails.HasAutoDelegationKind)
        {
            return null;
        }

        var result = delegationDetails.AutoDelegationKind switch
        {
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Executor => EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Executor,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Approval => EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Approval,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Chief => EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Chief,
            _ => throw new ArgumentOutOfRangeException(nameof(delegationDetails.AutoDelegationKind), delegationDetails.AutoDelegationKind, null)
        };

        return result;
    }
}
