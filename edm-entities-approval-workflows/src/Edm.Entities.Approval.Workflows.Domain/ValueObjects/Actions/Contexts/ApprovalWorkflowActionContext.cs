using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;

public sealed class ApprovalWorkflowActionContext
{
    internal ApprovalWorkflowActionContext(
        ApprovalWorkflow workflow,
        ApprovalWorkflowStage activeStage,
        ApprovalWorkflowGroup[] activeGroups,
        Id<Employee> currentUserId,
        bool currentUserIsOwner,
        bool currentUserIsAdmin)
    {
        Workflow = workflow;
        ActiveStage = activeStage;
        ActiveGroups = activeGroups;
        CurrentUserId = currentUserId;
        CurrentUserIsOwner = currentUserIsOwner;
        CurrentUserIsAdmin = currentUserIsAdmin;
    }

    public ApprovalWorkflow Workflow { get; }
    internal ApprovalWorkflowStage ActiveStage { get; }
    internal ApprovalWorkflowGroup[] ActiveGroups { get; }
    internal Id<Employee> CurrentUserId { get; }
    internal bool CurrentUserIsOwner { get; }
    internal bool CurrentUserIsAdmin { get; }
}
