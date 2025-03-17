using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Detectors.RootAssignments.Contexts;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Detectors.RootAssignments;

public static class ApprovalWorkflowRootAssignmentDetector
{
    public static ApprovalWorkflowRootAssignmentContext[] Detect(ApprovalWorkflowGroup group)
    {
        Dictionary<Id<ApprovalWorkflowAssignment>, ApprovalWorkflowAssignment> delegatedAssignmentsByDelegatedToId = group.Assignments
            .Where(a => a.CompletionDetails?.DelegationDetails is not null)
            .ToDictionary(a => a.CompletionDetails!.DelegationDetails!.DelegatedToId);

        ApprovalWorkflowRootAssignmentContext[] result = group.Assignments
            .Where(a => a is { IsActive: true, IsFixed: false })
            .Select(a => DetectRootAssignment(a, delegatedAssignmentsByDelegatedToId))
            .ToArray();

        return result;
    }

    private static ApprovalWorkflowRootAssignmentContext DetectRootAssignment(
        ApprovalWorkflowAssignment assignmentToDelegate,
        Dictionary<Id<ApprovalWorkflowAssignment>, ApprovalWorkflowAssignment> delegatedAssignmentsByDelegatedToId)
    {
        ApprovalWorkflowAssignment rootAssignment = assignmentToDelegate;

        while (true)
        {
            ApprovalWorkflowAssignment? parentAssignment =
                delegatedAssignmentsByDelegatedToId.GetValueOrDefault(rootAssignment.Id);

            if (parentAssignment is null)
            {
                var result = new ApprovalWorkflowRootAssignmentContext(rootAssignment, assignmentToDelegate);

                return result;
            }

            rootAssignment = parentAssignment;
        }
    }
}
