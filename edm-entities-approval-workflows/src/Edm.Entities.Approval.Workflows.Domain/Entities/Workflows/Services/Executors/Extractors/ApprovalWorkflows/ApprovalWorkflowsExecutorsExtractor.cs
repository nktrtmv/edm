using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.ApprovalWorkflows;

public static class ApprovalWorkflowsExecutorsExtractor
{
    public static Id<Employee>[] ExtractAll(ApprovalWorkflow[] workflows)
    {
        Id<Employee>[] result = workflows
            .SelectMany(ExtractGroups)
            .SelectMany(g => g.Assignments)
            .Select(a => a.ExecutorId)
            .Distinct()
            .ToArray();

        return result;
    }

    public static Id<Employee>[] ExtractCurrent(ApprovalWorkflow[] workflows)
    {
        ApprovalWorkflowGroup[] groups = workflows
            .SelectMany(ExtractGroups)
            .Where(g => g.Status is ApprovalWorkflowGroupStatus.InProgress)
            .ToArray();

        Id<Employee>[] result = ActiveApprovalWorkflowGroupsExecutorsExtractor.Extract(groups);

        return result;
    }

    private static ApprovalWorkflowGroup[] ExtractGroups(ApprovalWorkflow workflow)
    {
        ApprovalWorkflowGroup[] result = workflow.State.Stages.SelectMany(s => s.Groups).ToArray();

        return result.ToArray();
    }
}
