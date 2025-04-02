using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.DelegationDetails.
    AutoDelegationKinds;

internal static class EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal FromExternal(EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal autoDelegationKind)
    {
        EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal result = autoDelegationKind switch
        {
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Executor => EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal.Executor,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Approval => EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal.Approval,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Chief => EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal.Chief,
            _ => throw new ArgumentTypeOutOfRangeException(autoDelegationKind)
        };

        return result;
    }
}
