using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades.GroupAdapters;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades;

internal sealed class ApprovalWorkflowsGroupsFacade
{
    public ApprovalWorkflowsGroupsFacade(IEnumerable<IApprovalWorkflowGroupAdapter> adaptersByApprovalGroupType)
    {
        AdaptersByApprovalGroupType = adaptersByApprovalGroupType.ToDictionary(a => a.ApprovalGroupType);
    }

    private Dictionary<Type, IApprovalWorkflowGroupAdapter> AdaptersByApprovalGroupType { get; }

    internal async Task CreateRootAssignments(ApprovalWorkflowGroup group, ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        IApprovalWorkflowGroupAdapter adapter = GetRequiredAdapter(group);

        await adapter.CreateRootAssignments(group, workflow, cancellationToken);
    }

    internal Id<Employee>[] CollectPotentialSubstitutorsIds(ApprovalWorkflowGroup group)
    {
        IApprovalWorkflowGroupAdapter adapter = GetRequiredAdapter(group);

        Id<Employee>[] result = adapter.CollectPotentialSubstitutorsIds(group);

        return result;
    }

    internal ApprovalWorkflowAssignment[] ActualizeAssignments(ApprovalWorkflowGroup group, ApprovalWorkflowAssignmentsAutoDelegator[] delegators)
    {
        IApprovalWorkflowGroupAdapter adapter = GetRequiredAdapter(group);

        ApprovalWorkflowAssignment[] result = adapter.ActualizeAssignments(group, delegators);

        return result;
    }

    private IApprovalWorkflowGroupAdapter GetRequiredAdapter(ApprovalWorkflowGroup group)
    {
        Type approvalGroupType = group.ApprovalGroup.GetType();

        IApprovalWorkflowGroupAdapter? adapter = AdaptersByApprovalGroupType.GetValueOrDefault(approvalGroupType);

        if (adapter is null)
        {
            throw new ApplicationException($"Failed to detect group adapter.\nGroup:{group}");
        }

        return adapter;
    }
}
