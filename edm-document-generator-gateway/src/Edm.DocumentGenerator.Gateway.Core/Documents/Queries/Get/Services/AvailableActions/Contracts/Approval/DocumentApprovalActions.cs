using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts.Approval;

internal sealed class DocumentApprovalActions
{
    internal DocumentApprovalActions(
        string workflowId,
        string stageId,
        EntitiesApprovalWorkflowActionKindExternal[] actions,
        EntitiesApprovalWorkflowStageTypeExternal stageType)
    {
        WorkflowId = workflowId;
        StageId = stageId;
        Actions = actions;
        StageType = stageType;
    }

    internal string WorkflowId { get; }
    internal string StageId { get; }
    internal EntitiesApprovalWorkflowActionKindExternal[] Actions { get; }
    private EntitiesApprovalWorkflowStageTypeExternal StageType { get; }
    internal bool IsMasterStage => StageType == EntitiesApprovalWorkflowStageTypeExternal.ParallelAny;
}
