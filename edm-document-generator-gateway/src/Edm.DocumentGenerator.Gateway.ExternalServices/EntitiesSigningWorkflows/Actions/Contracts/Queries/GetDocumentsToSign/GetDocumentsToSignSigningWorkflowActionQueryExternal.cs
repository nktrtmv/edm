namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign;

public sealed class GetDocumentsToSignSigningWorkflowActionQueryExternal
{
    public GetDocumentsToSignSigningWorkflowActionQueryExternal(string workflowId, string currentUserId, bool isCurrentUserAdmin)
    {
        WorkflowId = workflowId;
        CurrentUserId = currentUserId;
        IsCurrentUserAdmin = isCurrentUserAdmin;
    }

    public string WorkflowId { get; }
    public string CurrentUserId { get; }
    public bool IsCurrentUserAdmin { get; }
}
