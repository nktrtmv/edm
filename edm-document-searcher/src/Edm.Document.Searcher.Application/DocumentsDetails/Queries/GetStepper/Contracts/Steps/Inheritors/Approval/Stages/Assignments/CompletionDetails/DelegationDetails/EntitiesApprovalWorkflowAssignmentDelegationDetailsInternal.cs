using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails;

public sealed record EntitiesApprovalWorkflowAssignmentDelegationDetailsInternal(
    string DelegatedToId,
    EntitiesApprovalWorkflowAssignmentAutoDelegationKindInternal? AutoDelegationKind);
