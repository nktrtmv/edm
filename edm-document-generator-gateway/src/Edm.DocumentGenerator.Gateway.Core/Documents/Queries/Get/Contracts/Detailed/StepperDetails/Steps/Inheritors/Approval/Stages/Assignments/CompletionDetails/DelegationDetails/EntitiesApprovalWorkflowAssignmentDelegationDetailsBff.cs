using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails.AutoDelegationKinds;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails;

public sealed class EntitiesApprovalWorkflowAssignmentDelegationDetailsBff
{
    public EntitiesApprovalWorkflowAssignmentDelegationDetailsBff(
        string delegatedToId,
        EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff? autoDelegationKind)
    {
        DelegatedToId = delegatedToId;
        AutoDelegationKind = autoDelegationKind;
    }

    public string DelegatedToId { get; }
    public EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff? AutoDelegationKind { get; }
}
