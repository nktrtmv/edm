using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    DelegationDetails.Kinds;

internal static class EntitiesApprovalWorkflowAssignmentAutoDelegationKindDtoConverter
{
    internal static EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto FromInternal(ApprovalWorkflowAssignmentAutoDelegationKindInternal autoDelegationKind)
    {
        EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto result = autoDelegationKind switch
        {
            ApprovalWorkflowAssignmentAutoDelegationKindInternal.Executor => EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Executor,
            ApprovalWorkflowAssignmentAutoDelegationKindInternal.Approval => EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Approval,
            ApprovalWorkflowAssignmentAutoDelegationKindInternal.Chief => EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Chief,
            _ => throw new ArgumentTypeOutOfRangeException(autoDelegationKind)
        };

        return result;
    }
}
