using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;

public sealed class SigningActionContext
{
    public SigningActionContext(
        SigningWorkflow workflow,
        Id<User> currentUserId,
        bool isCurrentUserAdmin)
    {
        Workflow = workflow;
        CurrentUserId = currentUserId;
        IsCurrentUserAdmin = isCurrentUserAdmin;
    }

    internal SigningWorkflow Workflow { get; }
    internal Id<User> CurrentUserId { get; }
    internal bool IsCurrentUserAdmin { get; }

    public override string ToString()
    {
        return $"workflow: ({Workflow}), userId: {CurrentUserId}, isUserAdmin: {IsCurrentUserAdmin}";
    }
}
