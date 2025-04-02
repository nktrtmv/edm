using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval;

public sealed class DocumentWorkflowApprovalStepBff : DocumentWorkflowStepBff
{
    public EntitiesApprovalWorkflowStageBff[] Stages { get; init; } = Array.Empty<EntitiesApprovalWorkflowStageBff>();
    public required ApprovalRuleKeyBff? ApprovalRuleKey { get; init; }
}
