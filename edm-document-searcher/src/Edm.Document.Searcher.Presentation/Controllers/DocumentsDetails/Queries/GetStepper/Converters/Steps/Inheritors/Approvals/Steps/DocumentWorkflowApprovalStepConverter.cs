using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.ApprovalRuleKeys;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps;

internal static class DocumentWorkflowApprovalStepConverter
{
    internal static DocumentWorkflowApprovalStepDto FromInternal(DocumentWorkflowApprovalStepInternal step)
    {
        var stages = step.Stages.Select(EntitiesApprovalWorkflowStageConverter.FromInternal);

        var result = new DocumentWorkflowApprovalStepDto
        {
            ApprovalRuleKey = NullableConverter.Convert(step.ApprovalRuleKey, ApprovalRuleKeyConverter.FromInternal),
            Stages = { stages }
        };

        return result;
    }
}
