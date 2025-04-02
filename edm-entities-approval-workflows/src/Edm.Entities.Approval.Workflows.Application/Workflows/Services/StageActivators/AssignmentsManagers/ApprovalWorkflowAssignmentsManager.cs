using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto.Contracts.ExecutorDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Detectors.RootAssignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Detectors.RootAssignments.Contexts;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers;

internal sealed class ApprovalWorkflowAssignmentsManager
{
    public ApprovalWorkflowAssignmentsManager(ApprovalWorkflowsGroupsFacade groups)
    {
        Groups = groups;
    }

    private ApprovalWorkflowsGroupsFacade Groups { get; }

    internal async Task CreateRootAssignments(ApprovalWorkflowGroup[] groups, ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        var tasks = groups
            .Select(g => Groups.CreateRootAssignments(g, workflow, cancellationToken))
            .ToArray();

        await Task.WhenAll(tasks);
    }

    internal ApprovalWorkflowAssignment[] ActualizeAssignments(
        DomainId domainId,
        ApprovalWorkflowGroup[] groups,
        UtcDateTime<ApprovalWorkflowState> actualizeDate,
        CancellationToken cancellationToken)
    {
        var rootAssignmentsByGroup
            = groups.ToDictionary(group => group, ApprovalWorkflowRootAssignmentDetector.Detect);

        Id<Employee>[] potentialExecutorsIds = CollectPotentialExecutorsIds(groups, rootAssignmentsByGroup);

        string[] failedExecutorIds = potentialExecutorsIds.Where(x => !Guid.TryParse(x.Value, out var _))
            .Select(x => x.Value)
            .ToArray();

        if (failedExecutorIds.Length > 0)
        {
            string[] groupsMessage = groups.Select(x => x.ToString()).ToArray();

            throw new ApplicationException(
                $"""
                 Некорректные Guid согласующих: {string.Join(", ", failedExecutorIds)}.
                 Группы согласований:
                 {string.Join("\n", groupsMessage)}
                 """);
        }

        ApprovalWorkflowAssignmentExecutorDetails[] executorsDetails =
            potentialExecutorsIds.Select(p => new ApprovalWorkflowAssignmentExecutorDetails(p, p)).ToArray();

        Dictionary<Id<Employee>, ApprovalWorkflowAssignmentExecutorDetails> executorsDetailsById = executorsDetails
            .ToDictionary(e => e.PotentialExecutorId);

        Dictionary<ApprovalWorkflowGroup, ApprovalWorkflowAssignmentsAutoDelegator[]> delegatorsByGroup = rootAssignmentsByGroup.ToDictionary(
            a => a.Key,
            a => ApprovalWorkflowAssignmentsAutoDelegatorsFactory.CreateFrom(a.Value, executorsDetailsById));

        ApprovalWorkflowAssignment[] result = groups
            .SelectMany(g => Groups.ActualizeAssignments(g, delegatorsByGroup[g]))
            .ToArray();

        return result;
    }

    private Id<Employee>[] CollectPotentialExecutorsIds(
        ApprovalWorkflowGroup[] groups,
        Dictionary<ApprovalWorkflowGroup, ApprovalWorkflowRootAssignmentContext[]> rootAssignmentsByGroup)
    {
        var rootExecutorsIds = rootAssignmentsByGroup
            .SelectMany(a => a.Value)
            .Select(a => a.RootAssignment.ExecutorId)
            .ToArray();

        Id<Employee>[] actualExecutorsIds = ActiveApprovalWorkflowGroupsExecutorsExtractor.Extract(groups);

        Id<Employee>[] potentialSubstitutesIds = groups
            .SelectMany(Groups.CollectPotentialSubstitutorsIds)
            .ToArray();

        Id<Employee>[] result = actualExecutorsIds
            .Concat(potentialSubstitutesIds)
            .Concat(rootExecutorsIds)
            .Distinct()
            .ToArray();

        return result;
    }
}
