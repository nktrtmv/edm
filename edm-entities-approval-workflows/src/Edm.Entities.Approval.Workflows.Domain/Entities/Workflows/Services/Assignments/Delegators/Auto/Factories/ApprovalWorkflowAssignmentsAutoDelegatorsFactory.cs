using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto.Contracts.ExecutorDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Detectors.RootAssignments.Contexts;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto.Factories;

public static class ApprovalWorkflowAssignmentsAutoDelegatorsFactory
{
    public static ApprovalWorkflowAssignmentsAutoDelegator[] CreateFrom(
        ApprovalWorkflowRootAssignmentContext[] rootAssignments,
        Dictionary<Id<Employee>, ApprovalWorkflowAssignmentExecutorDetails> executorsDetails)
    {
        ApprovalWorkflowAssignmentsAutoDelegator[] result = rootAssignments
            .Select(c => CreateDelegator(c, executorsDetails))
            .ToArray();

        return result;
    }

    private static ApprovalWorkflowAssignmentsAutoDelegator CreateDelegator(
        ApprovalWorkflowRootAssignmentContext context,
        Dictionary<Id<Employee>, ApprovalWorkflowAssignmentExecutorDetails> availableExecutorsDetails)
    {
        var result = new ApprovalWorkflowAssignmentsAutoDelegator(
            context.RootAssignment,
            context.AssignmentToDelegate,
            availableExecutorsDetails);

        return result;
    }
}
