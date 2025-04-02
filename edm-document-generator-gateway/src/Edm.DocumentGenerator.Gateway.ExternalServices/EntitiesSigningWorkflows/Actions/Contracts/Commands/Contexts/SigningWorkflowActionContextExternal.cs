namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;

public sealed class SigningWorkflowActionContextExternal
{
    public SigningWorkflowActionContextExternal(string workflowId, string currentUserId, bool isCurrentUserAdmin)
    {
        WorkflowId = workflowId;
        CurrentUserId = currentUserId;
        IsCurrentUserAdmin = isCurrentUserAdmin;
    }

    public string WorkflowId { get; }
    public string CurrentUserId { get; }
    public bool IsCurrentUserAdmin { get; }
}
