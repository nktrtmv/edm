using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.Groups;

public static class ActiveApprovalWorkflowGroupsExecutorsExtractor
{
    public static Id<Employee>[] Extract(ApprovalWorkflowGroup[] groups)
    {
        Id<Employee>[] result = groups
            .SelectMany(g => g.Assignments)
            .Where(a => a.IsActive)
            .Select(a => a.ExecutorId)
            .Distinct()
            .ToArray();

        return result;
    }
}
