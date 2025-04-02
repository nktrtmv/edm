using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades.GroupAdapters;

public interface IApprovalWorkflowGroupAdapter
{
    Type ApprovalGroupType { get; }
    Task CreateRootAssignments(ApprovalWorkflowGroup group, ApprovalWorkflow workflow, CancellationToken cancellationToken);
    Id<Employee>[] CollectPotentialSubstitutorsIds(ApprovalWorkflowGroup group);
    ApprovalWorkflowAssignment[] ActualizeAssignments(ApprovalWorkflowGroup group, ApprovalWorkflowAssignmentsAutoDelegator[] delegators);
}
