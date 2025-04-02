using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails.ValueObjects.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.
    AutoDelegationKinds;

internal static class ApprovalWorkflowAssignmentAutoDelegationKindDbConverter
{
    internal static ApprovalWorkflowAssignmentAutoDelegationKindDb FromDomain(ApprovalWorkflowAssignmentAutoDelegationKind autoDelegationKind)
    {
        ApprovalWorkflowAssignmentAutoDelegationKindDb result = autoDelegationKind switch
        {
            ApprovalWorkflowAssignmentAutoDelegationKind.Executor => ApprovalWorkflowAssignmentAutoDelegationKindDb.Executor,
            ApprovalWorkflowAssignmentAutoDelegationKind.Approval => ApprovalWorkflowAssignmentAutoDelegationKindDb.Approval,
            ApprovalWorkflowAssignmentAutoDelegationKind.Chief => ApprovalWorkflowAssignmentAutoDelegationKindDb.Chief,
            _ => throw new ArgumentTypeOutOfRangeException(autoDelegationKind)
        };

        return result;
    }

    internal static ApprovalWorkflowAssignmentAutoDelegationKind ToDomain(ApprovalWorkflowAssignmentAutoDelegationKindDb autoDelegationKind)
    {
        ApprovalWorkflowAssignmentAutoDelegationKind result = autoDelegationKind switch
        {
            ApprovalWorkflowAssignmentAutoDelegationKindDb.Executor => ApprovalWorkflowAssignmentAutoDelegationKind.Executor,
            ApprovalWorkflowAssignmentAutoDelegationKindDb.Approval => ApprovalWorkflowAssignmentAutoDelegationKind.Approval,
            ApprovalWorkflowAssignmentAutoDelegationKindDb.Chief => ApprovalWorkflowAssignmentAutoDelegationKind.Chief,
            _ => throw new ArgumentTypeOutOfRangeException(autoDelegationKind)
        };

        return result;
    }
}
