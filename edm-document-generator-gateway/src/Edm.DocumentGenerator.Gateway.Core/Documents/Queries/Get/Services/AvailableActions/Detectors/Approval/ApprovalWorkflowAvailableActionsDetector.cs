using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval.Kinds;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Detectors.Approval;

internal static class ApprovalWorkflowAvailableActionsDetector
{
    internal static DocumentWorkflowApprovalActionsBff? Detect(DocumentAvailableActions availableActions)
    {
        if (availableActions.Approval is null)
        {
            return null;
        }

        var actions = DetectActions(availableActions.Approval.Actions);

        var context = new DocumentWorkflowApprovalActionsContextBff
        {
            WorkflowId = availableActions.Approval.WorkflowId,
            StageId = availableActions.Approval.StageId
        };

        var result = new DocumentWorkflowApprovalActionsBff
        {
            Context = context,
            Actions = actions
        };

        return result;
    }

    private static DocumentWorkflowApprovalActionKindBff[] DetectActions(EntitiesApprovalWorkflowActionKindExternal[] approvalActions)
    {
        var result = approvalActions.Select(DocumentWorkflowApprovalActionKindBffConverter.FromExternal).ToArray();

        return result;
    }
}
