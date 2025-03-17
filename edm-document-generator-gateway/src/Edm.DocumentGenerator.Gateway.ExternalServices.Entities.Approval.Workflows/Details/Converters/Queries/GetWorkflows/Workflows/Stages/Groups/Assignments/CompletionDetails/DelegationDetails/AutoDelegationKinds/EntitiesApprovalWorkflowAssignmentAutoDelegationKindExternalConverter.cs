using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;

internal static class EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal FromDto(EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto autoDelegationKind)
    {
        var result = autoDelegationKind switch
        {
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Executor => EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Executor,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Approval => EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Approval,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindDto.Chief => EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Chief,
            _ => throw new ArgumentTypeOutOfRangeException(autoDelegationKind)
        };

        return result;
    }
}
