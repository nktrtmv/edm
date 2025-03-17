using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.CompletionDetails.ValueObjects.DelegationDetails;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.
    DelegationDetails;

internal static class ApprovalWorkflowAssignmentDelegationDetailsInternalConverter
{
    internal static ApprovalWorkflowAssignmentDelegationDetailsInternal FromDomain(ApprovalWorkflowAssignmentDelegationDetails details)
    {
        Id<ApprovalWorkflowAssignmentInternal> delegatedToId =
            IdConverterFrom<ApprovalWorkflowAssignmentInternal>.From(details.DelegatedToId);

        ApprovalWorkflowAssignmentAutoDelegationKindInternal? autoDelegationKind =
            NullableConverter.Convert(details.AutoDelegationKind, ApprovalWorkflowAssignmentAutoDelegationKindInternalConverter.FromDomain);

        var result = new ApprovalWorkflowAssignmentDelegationDetailsInternal(delegatedToId, autoDelegationKind);

        return result;
    }
}
