using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

public sealed class SigningActionContextInternal
{
    public SigningActionContextInternal(Id<SigningInternal> workflowId, Id<UserInternal> currentUserId, bool isCurrentUserAdmin)
    {
        WorkflowId = workflowId;
        CurrentUserId = currentUserId;
        IsCurrentUserAdmin = isCurrentUserAdmin;
    }

    public Id<SigningInternal> WorkflowId { get; }
    public Id<UserInternal> CurrentUserId { get; }
    public bool IsCurrentUserAdmin { get; }
}
