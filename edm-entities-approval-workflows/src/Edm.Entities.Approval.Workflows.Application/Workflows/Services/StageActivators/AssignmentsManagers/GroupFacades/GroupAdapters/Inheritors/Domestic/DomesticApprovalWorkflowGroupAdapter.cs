using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades.GroupAdapters.Abstractions;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto.Contracts.ExecutorDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic.ValueObjects.ApprovalParticipants;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails.ValueObjects.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades.GroupAdapters.Inheritors.Domestic;

internal sealed class DomesticApprovalWorkflowGroupAdapter : ApprovalWorkflowGroupAdapterGeneric<ApprovalWorkflowDomesticApprovalGroup>
{
    protected override Task<Id<Employee>[]> CollectRootExecutorsIds(
        ApprovalWorkflowDomesticApprovalGroup approvalGroup,
        ApprovalWorkflow workflow,
        CancellationToken cancellationToken)
    {
        var result = approvalGroup.Participants
            .Select(p => p.MainEmployeeId)
            .ToArray();

        return Task.FromResult(result);
    }

    protected override Id<Employee>[] CollectPotentialSubstitutorsIds(ApprovalWorkflowDomesticApprovalGroup approvalGroup)
    {
        var result = approvalGroup.Participants
            .SelectMany(p => p.SubstituteEmployeesIds)
            .ToArray();

        return result;
    }

    protected override ApprovalWorkflowAssignment[] ActualizeAssignments(
        ApprovalWorkflowAssignmentsAutoDelegator[] delegators,
        ApprovalWorkflowDomesticApprovalGroup approvalGroup)
    {
        var participants = approvalGroup.Participants
            .ToDictionary(p => p.MainEmployeeId);

        ApprovalWorkflowAssignment[] result = delegators
            .SelectMany(d => ActualizeAssignment(d, participants))
            .ToArray();

        return result;
    }

    private static ApprovalWorkflowAssignment[] ActualizeAssignment(
        ApprovalWorkflowAssignmentsAutoDelegator delegator,
        Dictionary<Id<Employee>, ApprovalWorkflowApprovalParticipant> participants)
    {
        var rootExecutorId = delegator.RootExecutorId;

        var participant = participants.GetValueOrDefault(rootExecutorId);

        _ = delegator.TryToDelegate(rootExecutorId, d => d.AvailableExecutorId, ApprovalWorkflowAssignmentAutoDelegationKind.Executor) ||
            delegator.TryToDelegate(rootExecutorId, TryToSelectPotentialExecutor(participant), ApprovalWorkflowAssignmentAutoDelegationKind.Executor) ||
            delegator.TryToDelegate(rootExecutorId, _ => rootExecutorId, ApprovalWorkflowAssignmentAutoDelegationKind.Executor);

        ApprovalWorkflowAssignment[] result = delegator.ToDelegatedAssignments();

        return result;
    }

    private static Func<ApprovalWorkflowAssignmentExecutorDetails, Id<Employee>?> TryToSelectPotentialExecutor(ApprovalWorkflowApprovalParticipant? participant)
    {
        return d => participant?.IsSubstitutionDisabled is true ? d.PotentialExecutorId : null;
    }
}
