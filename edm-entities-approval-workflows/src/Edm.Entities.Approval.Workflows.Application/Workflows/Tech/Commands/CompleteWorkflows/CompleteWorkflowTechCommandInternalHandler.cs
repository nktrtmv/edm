using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Commands.CompleteWorkflows.Contracts;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.CompletionDetails.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Commands.CompleteWorkflows;

[UsedImplicitly]
internal sealed class CompleteWorkflowTechCommandInternalHandler(ApprovalWorkflowsFacade approvalWorkflowsFacade) : IRequestHandler<CompleteWorkflowTechCommandInternal>
{
    public async Task Handle(CompleteWorkflowTechCommandInternal request, CancellationToken cancellationToken)
    {
        Id<ApprovalWorkflow> workflowId = IdConverterFrom<ApprovalWorkflow>.FromString(request.WorkflowId);

        ApprovalWorkflow workflow = await approvalWorkflowsFacade.GetRequired(workflowId, false, cancellationToken);

        if (workflow.IsCompleted)
        {
            return;
        }

        foreach (ApprovalWorkflowStage stage in workflow.State.Stages)
        {
            if (stage.IsCompleted)
            {
                continue;
            }

            CompleteGroups(stage.Groups);

            stage.SetStatus(ToStageStatus(request.CompleteStatus));

            if (stage.StartedDate is null)
            {
                stage.SetStartedDate(UtcDateTime<ApprovalWorkflowStage>.Now);
            }
        }

        workflow.State.SetStatus(request.CompleteStatus);

        await approvalWorkflowsFacade.Upsert(workflow, cancellationToken);
    }

    private static void CompleteGroups(ApprovalWorkflowGroup[] groups)
    {
        foreach (ApprovalWorkflowGroup group in groups)
        {
            if (group.Status is ApprovalWorkflowGroupStatus.Completed)
            {
                continue;
            }

            CompleteAssignments(group.Assignments);

            group.SetStatus(ApprovalWorkflowGroupStatus.Completed);
        }
    }

    private static void CompleteAssignments(ApprovalWorkflowAssignment[] assignments)
    {
        foreach (ApprovalWorkflowAssignment assignment in assignments)
        {
            if (assignment.IsCompleted)
            {
                continue;
            }

            assignment.SetCompletionDetails(
                ApprovalWorkflowAssignmentCompletionDetailsFactory.Create(ApprovalWorkflowAssignmentCompletionReason.CompletedAutomatically, null));

            assignment.SetStatus(ApprovalWorkflowAssignmentStatus.Completed);
        }
    }

    private static ApprovalWorkflowStageStatus ToStageStatus(ApprovalWorkflowStatus approvalWorkflowStatus)
    {
        ApprovalWorkflowStageStatus result = approvalWorkflowStatus switch
        {
            ApprovalWorkflowStatus.Approved => ApprovalWorkflowStageStatus.Approved,
            ApprovalWorkflowStatus.Rejected => ApprovalWorkflowStageStatus.Rejected,
            ApprovalWorkflowStatus.ReturnedToRework => ApprovalWorkflowStageStatus.ReturnedToRework,
            ApprovalWorkflowStatus.ApprovedWithRemark => ApprovalWorkflowStageStatus.ApprovedWithRemark,
            _ => throw new ArgumentOutOfRangeException(nameof(approvalWorkflowStatus), approvalWorkflowStatus, null)
        };

        return result;
    }
}
