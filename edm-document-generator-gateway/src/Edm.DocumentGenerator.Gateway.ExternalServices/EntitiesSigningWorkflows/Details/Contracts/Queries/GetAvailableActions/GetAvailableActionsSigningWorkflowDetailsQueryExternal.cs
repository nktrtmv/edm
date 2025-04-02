namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions;

public sealed class GetAvailableActionsSigningWorkflowDetailsQueryExternal
{
    public GetAvailableActionsSigningWorkflowDetailsQueryExternal(string workflowId, string currentUserId, bool isCurrentUserAdmin)
    {
        WorkflowId = workflowId;
        CurrentUserId = currentUserId;
        IsCurrentUserAdmin = isCurrentUserAdmin;
    }

    public string WorkflowId { get; }
    public string CurrentUserId { get; }
    public bool IsCurrentUserAdmin { get; }
}
