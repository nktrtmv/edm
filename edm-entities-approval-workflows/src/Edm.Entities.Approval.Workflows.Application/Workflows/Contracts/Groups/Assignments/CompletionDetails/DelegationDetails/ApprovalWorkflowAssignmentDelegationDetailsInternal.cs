using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.
    DelegationDetails;

public sealed class ApprovalWorkflowAssignmentDelegationDetailsInternal
{
    public ApprovalWorkflowAssignmentDelegationDetailsInternal(
        Id<ApprovalWorkflowAssignmentInternal> delegatedToId,
        ApprovalWorkflowAssignmentAutoDelegationKindInternal? autoDelegationKind)
    {
        DelegatedToId = delegatedToId;
        AutoDelegationKind = autoDelegationKind;
    }

    public Id<ApprovalWorkflowAssignmentInternal> DelegatedToId { get; }
    public ApprovalWorkflowAssignmentAutoDelegationKindInternal? AutoDelegationKind { get; }
}
