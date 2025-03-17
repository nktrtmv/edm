using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails.ValueObjects.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.
    DelegationDetails;

public sealed class ApprovalWorkflowAssignmentDelegationDetails
{
    public ApprovalWorkflowAssignmentDelegationDetails(
        Id<ApprovalWorkflowAssignment> delegatedToId,
        ApprovalWorkflowAssignmentAutoDelegationKind? autoDelegationKind)
    {
        DelegatedToId = delegatedToId;
        AutoDelegationKind = autoDelegationKind;
    }

    public Id<ApprovalWorkflowAssignment> DelegatedToId { get; }
    public ApprovalWorkflowAssignmentAutoDelegationKind? AutoDelegationKind { get; }

    public override string ToString()
    {
        return $"{{ DelegatedToId: {DelegatedToId}, Kind: {AutoDelegationKind} }}";
    }
}
