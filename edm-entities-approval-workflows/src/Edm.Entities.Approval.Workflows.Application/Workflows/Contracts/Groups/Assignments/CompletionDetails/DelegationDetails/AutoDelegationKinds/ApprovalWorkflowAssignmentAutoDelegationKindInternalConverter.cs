using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.CompletionDetails.ValueObjects.DelegationDetails.ValueObjects.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;

internal static class ApprovalWorkflowAssignmentAutoDelegationKindInternalConverter
{
    internal static ApprovalWorkflowAssignmentAutoDelegationKindInternal FromDomain(ApprovalWorkflowAssignmentAutoDelegationKind autoDelegationKind)
    {
        ApprovalWorkflowAssignmentAutoDelegationKindInternal result = autoDelegationKind switch
        {
            ApprovalWorkflowAssignmentAutoDelegationKind.Executor => ApprovalWorkflowAssignmentAutoDelegationKindInternal.Executor,
            ApprovalWorkflowAssignmentAutoDelegationKind.Approval => ApprovalWorkflowAssignmentAutoDelegationKindInternal.Approval,
            ApprovalWorkflowAssignmentAutoDelegationKind.Chief => ApprovalWorkflowAssignmentAutoDelegationKindInternal.Chief,
            _ => throw new ArgumentTypeOutOfRangeException(autoDelegationKind)
        };

        return result;
    }
}
