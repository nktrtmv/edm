using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails.AutoDelegationKinds;

internal static class EntitiesApprovalWorkflowAssignmentAutoDelegationKindBffConverter
{
    internal static EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff FromExternal(EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal autoDelegationKind)
    {
        var result = autoDelegationKind switch
        {
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Executor => EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.Executor,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.ExecutorStaff => EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.ExecutorStaff,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Approval => EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.Approval,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.ApprovalStaff => EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.ApprovalStaff,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.Chief => EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.Chief,
            EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal.ChiefStaff => EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.ChiefStaff,
            _ => throw new ArgumentTypeOutOfRangeException(autoDelegationKind)
        };

        return result;
    }
}
