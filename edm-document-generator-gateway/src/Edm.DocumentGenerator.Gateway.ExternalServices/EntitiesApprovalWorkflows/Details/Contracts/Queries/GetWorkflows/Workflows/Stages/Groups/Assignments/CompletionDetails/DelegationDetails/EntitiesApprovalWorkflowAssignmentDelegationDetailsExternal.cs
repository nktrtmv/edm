using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;

using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

public sealed class EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal
{
    public EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal(
        Id<EntitiesApprovalWorkflowAssignmentExternal> delegatedToId,
        EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal? autoDelegationKind)
    {
        DelegatedToId = delegatedToId;
        AutoDelegationKind = autoDelegationKind;
    }

    public Id<EntitiesApprovalWorkflowAssignmentExternal> DelegatedToId { get; }
    public EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal? AutoDelegationKind { get; }
}
