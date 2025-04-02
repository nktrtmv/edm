using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Detectors;

internal static class ActiveGroupApprovalWorkflowsDetector
{
    internal static ApprovalWorkflowGroup GetRequired(ApprovalWorkflowGroup[] groups, Id<Employee> employeeId)
    {
        ApprovalWorkflowGroup? result = Get(groups, employeeId);

        if (result is not null)
        {
            return result;
        }

        string[] groupsStrings = groups.Select(g => g.ToString()).ToArray();

        string groupsString = string.Join(", ", groupsStrings);

        throw new ApplicationException(
            $"""
             User doesn't have an active assignments.
             UserId: {employeeId}
             Groups: [{groupsString}]
             """);
    }

    internal static ApprovalWorkflowGroup? Get(ApprovalWorkflowGroup[] groups, Id<Employee> employeeId)
    {
        ApprovalWorkflowGroup? result =
            groups.FirstOrDefault(g => UserHasInProgressAssignments(g, employeeId)) ??
            groups.FirstOrDefault(g => UserHasActiveAssignments(g, employeeId));

        return result;
    }

    private static bool UserHasInProgressAssignments(ApprovalWorkflowGroup group, Id<Employee> employeeId)
    {
        bool result = group.Assignments
            .Where(a => a.ExecutorId == employeeId)
            .Any(a => a.Status is ApprovalWorkflowAssignmentStatus.InProgress);

        return result;
    }

    private static bool UserHasActiveAssignments(ApprovalWorkflowGroup group, Id<Employee> employeeId)
    {
        bool result = group.Assignments
            .Where(a => a.ExecutorId == employeeId)
            .Any(a => a.IsActive);

        return result;
    }
}
