using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts.Factories;

public static class ApprovalWorkflowActionContextFactory
{
    public static ApprovalWorkflowActionContext CreateFrom(
        ApprovalWorkflow workflow,
        Id<Employee> currentUserId,
        bool currentUserIsOwner,
        bool currentUserIsAdmin)
    {
        var activeStage = workflow.State.Stages.FirstOrDefault(p => !p.IsCompleted);

        if (activeStage is null)
        {
            throw new ApplicationException("Cannot find active stage");
        }

        var result = CreateFrom(
            workflow,
            activeStage,
            currentUserId,
            currentUserIsOwner,
            currentUserIsAdmin);

        return result;
    }

    public static ApprovalWorkflowActionContext CreateFrom(
        ApprovalWorkflow workflow,
        Id<ApprovalWorkflowStage> stageId,
        Id<Employee> currentUserId,
        bool currentUserIsOwner,
        bool currentUserIsAdmin)
    {
        var activeStage = workflow.State.Stages.Single(p => p.Id == stageId);

        var result = CreateFrom(
            workflow,
            activeStage,
            currentUserId,
            currentUserIsOwner,
            currentUserIsAdmin);

        return result;
    }

    private static ApprovalWorkflowActionContext CreateFrom(
        ApprovalWorkflow workflow,
        ApprovalWorkflowStage activeStage,
        Id<Employee> currentUserId,
        bool currentUserIsOwner,
        bool currentUserIsAdmin)
    {
        var activeGroups = activeStage.Groups
            .Where(g => g.Status == ApprovalWorkflowGroupStatus.InProgress)
            .ToArray();

        var result = new ApprovalWorkflowActionContext(
            workflow,
            activeStage,
            activeGroups,
            currentUserId,
            currentUserIsOwner,
            currentUserIsAdmin);

        return result;
    }

    public static ApprovalWorkflowActionContext CreateExecutorContextFrom(
        ApprovalWorkflow workflow,
        Id<Employee> currentUserId)
    {
        var activeStage = workflow.State.Stages.FirstOrDefault(p => !p.IsCompleted);

        if (activeStage is null)
        {
            throw new ApplicationException("Cannot find active stage");
        }

        var result = CreateFrom(workflow, activeStage, currentUserId, false, false);

        return result;
    }

    public static ApprovalWorkflowActionContext CreateOwnerContextFrom(
        ApprovalWorkflow workflow,
        Id<Employee> currentUserId)
    {
        var activeStage = workflow.State.Stages.FirstOrDefault(p => !p.IsCompleted);

        if (activeStage is null)
        {
            throw new ApplicationException("Cannot find active stage");
        }

        var result = CreateFrom(workflow, activeStage, currentUserId, true, false);

        return result;
    }
}
