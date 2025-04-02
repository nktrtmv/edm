using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.Statuses;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments;

public sealed record EntitiesApprovalWorkflowAssignmentInternal(
    string Id,
    int Number,
    string Executor,
    EntitiesApprovalWorkflowAssignmentStatusInternal Status,
    DateTime CreatedDate,
    EntitiesApprovalWorkflowAssignmentCompletionDetailsInternal? CompletionDetails,
    string? Author,
    bool IsFixed);
