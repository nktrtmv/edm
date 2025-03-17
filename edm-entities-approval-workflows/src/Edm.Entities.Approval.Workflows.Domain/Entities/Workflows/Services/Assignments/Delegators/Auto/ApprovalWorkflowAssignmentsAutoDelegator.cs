using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto.Contracts.ExecutorDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails.ValueObjects.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto;

public sealed class ApprovalWorkflowAssignmentsAutoDelegator
{
    public ApprovalWorkflowAssignmentsAutoDelegator(
        ApprovalWorkflowAssignment rootAssignment,
        ApprovalWorkflowAssignment assignmentToDelegate,
        Dictionary<Id<Employee>, ApprovalWorkflowAssignmentExecutorDetails> executorsDetails)
    {
        RootAssignment = rootAssignment;
        AssignmentToDelegate = assignmentToDelegate;
        ExecutorsDetails = executorsDetails;
    }

    private ApprovalWorkflowAssignment RootAssignment { get; }
    private ApprovalWorkflowAssignment AssignmentToDelegate { get; }
    private Dictionary<Id<Employee>, ApprovalWorkflowAssignmentExecutorDetails> ExecutorsDetails { get; }
    private List<ApprovalWorkflowAssignment> DelegatedAssignments { get; } = new List<ApprovalWorkflowAssignment>();

    public Id<Employee> RootExecutorId => RootAssignment.ExecutorId;

    public bool TryToDelegate(
        Id<Employee> delegateToUserId,
        Func<ApprovalWorkflowAssignmentExecutorDetails, Id<Employee>?> selector,
        ApprovalWorkflowAssignmentAutoDelegationKind autoDelegationKind)
    {
        ApprovalWorkflowAssignmentExecutorDetails executorDetails = ExecutorsDetails[delegateToUserId];

        Id<Employee>? executorId = selector(executorDetails);

        if (executorId is null)
        {
            return false;
        }

        if (AssignmentToDelegate.ExecutorId == executorId)
        {
            return true;
        }

        ApprovalWorkflowAssignment delegatedAssignment = ApprovalWorkflowAssignmentFactory.CreateNew(
            executorId,
            AssignmentToDelegate.Status);

        DelegatedAssignments.Add(delegatedAssignment);

        ApprovalWorkflowAssignmentStateUpdater.SetAutoDelegated(AssignmentToDelegate, delegatedAssignment.Id, autoDelegationKind);

        return true;
    }

    public ApprovalWorkflowAssignment[] ToDelegatedAssignments()
    {
        ApprovalWorkflowAssignment[] result = DelegatedAssignments.ToArray();

        return result;
    }
}
