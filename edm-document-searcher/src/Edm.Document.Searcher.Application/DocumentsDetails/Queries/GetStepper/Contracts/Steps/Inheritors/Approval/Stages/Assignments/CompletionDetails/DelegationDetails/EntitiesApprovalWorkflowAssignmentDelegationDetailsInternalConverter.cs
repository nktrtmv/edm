using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails;

internal static class EntitiesApprovalWorkflowAssignmentDelegationDetailsInternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentDelegationDetailsInternal FromDomain(EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal details)
    {
        var delegatedToId = IdConverterTo.ToString(details.DelegatedToId);

        EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal? autoDelegationKind =
            NullableConverter.Convert(details.AutoDelegationKind, EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternalConverter.FromExternal);

        var result = new EntitiesApprovalWorkflowAssignmentDelegationDetailsInternal(delegatedToId, autoDelegationKind);

        return result;
    }
}
