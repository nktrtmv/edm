using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Transformers.Inheritors.Approval;

internal sealed class DocumentWorkflowApprovalStepTransformer(
    EntitiesApprovalWorkflowExternal[] workflows,
    DocumentConversionContext conversionContext) : DocumentWorkflowStepTransformer<EntitiesApprovalWorkflowExternal>(
    workflows,
    DocumentStatusTypeBff.Approval,
    conversionContext)
{
    protected override DocumentWorkflowStepBff Transform(DocumentWorkflowStepBff step, EntitiesApprovalWorkflowExternal workflow)
    {
        var stages = EntitiesApprovalWorkflowStageBffConverter.FromExternal(workflow, ConversionContext);

        var approvalRuleKey = NullableConverter.Convert(workflow.ApprovalRuleKey, ApprovalRuleKeyBffConverter.FromExternal);

        var result = new DocumentWorkflowApprovalStepBff
        {
            Number = step.Number,
            Status = step.Status,
            Date = step.Date,
            Stages = stages,
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
