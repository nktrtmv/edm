using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Transformers.Inheritors.Approval;

internal sealed class DocumentWorkflowApprovalStepTransformer(
    EntitiesApprovalWorkflowExternal[] workflows,
    DocumentConversionContext conversionContext) : DocumentWorkflowStepTransformer<EntitiesApprovalWorkflowExternal>(
    workflows,
    DocumentStatusTypeInternal.Approval,
    conversionContext)
{
    protected override DocumentWorkflowStepInternal Transform(DocumentWorkflowStepInternal step, EntitiesApprovalWorkflowExternal workflow)
    {
        var stages = EntitiesApprovalWorkflowStageInternalConverter.FromExternal(workflow, ConversionContext);

        var approvalRuleKey = NullableConverter.Convert(workflow.ApprovalRuleKey, ApprovalRuleKeyInternalConverter.FromExternal);

        var result = new DocumentWorkflowApprovalStepInternal
        {
            Number = step.Number,
            Status = step.Status,
            Date = step.Date,
            Stages = stages,
            ApprovalRuleKey = approvalRuleKey,
            Responsible = step.Responsible
        };

        return result;
    }
}
