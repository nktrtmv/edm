using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

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
