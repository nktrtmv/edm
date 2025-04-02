namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Contracts.Contexts;

public sealed class EntitiesApprovalWorkflowActionContextExternal
{
    public EntitiesApprovalWorkflowActionContextExternal(string workflowId, string stageId, string currentUserId)
    {
        WorkflowId = workflowId;
        StageId = stageId;
        CurrentUserId = currentUserId;
    }

    public string WorkflowId { get; }
    public string StageId { get; }
    public string CurrentUserId { get; }
}
