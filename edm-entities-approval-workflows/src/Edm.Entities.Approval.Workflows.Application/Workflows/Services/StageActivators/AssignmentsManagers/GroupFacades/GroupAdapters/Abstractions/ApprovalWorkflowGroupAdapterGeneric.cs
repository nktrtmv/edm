using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Extensions.Types;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades.GroupAdapters.Abstractions;

internal abstract class ApprovalWorkflowGroupAdapterGeneric<T> : IApprovalWorkflowGroupAdapter
    where T : ApprovalWorkflowApprovalGroup
{
    public Type ApprovalGroupType => typeof(T);

    async Task IApprovalWorkflowGroupAdapter.CreateRootAssignments(ApprovalWorkflowGroup group, ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        T approvalGroup = TypeCasterTo<T>.CastRequired(group.ApprovalGroup);

        Id<Employee>[] rootExecutorsIds = await CollectRootExecutorsIds(approvalGroup, workflow, cancellationToken);

        ApprovalWorkflowAssignment[] rootAssignments = rootExecutorsIds
            .Select(e => ApprovalWorkflowAssignmentFactory.CreateNew(e, ApprovalWorkflowAssignmentStatus.NotStarted))
            .ToArray();

        group.SetAssignments(rootAssignments);
    }

    Id<Employee>[] IApprovalWorkflowGroupAdapter.CollectPotentialSubstitutorsIds(ApprovalWorkflowGroup group)
    {
        T approvalGroup = TypeCasterTo<T>.CastRequired(group.ApprovalGroup);

        Id<Employee>[] result = CollectPotentialSubstitutorsIds(approvalGroup);

        return result;
    }

    ApprovalWorkflowAssignment[] IApprovalWorkflowGroupAdapter.ActualizeAssignments(ApprovalWorkflowGroup group, ApprovalWorkflowAssignmentsAutoDelegator[] delegators)
    {
        T approvalGroup = TypeCasterTo<T>.CastRequired(group.ApprovalGroup);

        ApprovalWorkflowAssignment[] delegatedAssignments = ActualizeAssignments(delegators, approvalGroup);

        ApprovalWorkflowAssignment[] assignments = group.Assignments
            .Concat(delegatedAssignments)
            .ToArray();

        group.SetAssignments(assignments);

        return delegatedAssignments;
    }

    protected abstract Task<Id<Employee>[]> CollectRootExecutorsIds(T approvalGroup, ApprovalWorkflow workflow, CancellationToken cancellationToken);

    protected abstract Id<Employee>[] CollectPotentialSubstitutorsIds(T approvalGroup);

    protected abstract ApprovalWorkflowAssignment[] ActualizeAssignments(ApprovalWorkflowAssignmentsAutoDelegator[] delegators, T approvalGroup);
}
