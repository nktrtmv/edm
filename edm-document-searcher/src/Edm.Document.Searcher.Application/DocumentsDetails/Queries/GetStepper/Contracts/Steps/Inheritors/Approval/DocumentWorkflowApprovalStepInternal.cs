using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval;

public sealed class DocumentWorkflowApprovalStepInternal : DocumentWorkflowStepInternal
{
    public EntitiesApprovalWorkflowStageInternal[] Stages { get; init; } = Array.Empty<EntitiesApprovalWorkflowStageInternal>();
    public required ApprovalRuleKeyInternal? ApprovalRuleKey { get; init; }
}
