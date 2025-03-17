using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Factories;

public static class ApprovalWorkflowFactory
{
    public static ApprovalWorkflow CreateNew(
        Id<ApprovalWorkflow> id,
        ApprovalWorkflowParameters parameters,
        ApprovalWorkflowStage[] stages,
        Id<Employee> ownerId,
        Id<Employee>? documentAuthorId)
    {
        Audit<ApprovalWorkflow> audit = AuditConverterFrom<ApprovalWorkflow>.FromNow();

        var state = ApprovalWorkflowStateFactory.CreateNew(stages, [ownerId], documentAuthorId);

        var participantsChangedEvent = new ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent();

        var applicationEvents = new List<ApprovalWorkflowApplicationEvent>
        {
            participantsChangedEvent
        };

        var result = new ApprovalWorkflow(id, parameters, state, applicationEvents, audit);

        return result;
    }

    public static ApprovalWorkflow CreateFrom(ApprovalWorkflow workflow, bool isLocked)
    {
        var result = CreateFrom(workflow, workflow.Audit, isLocked);

        return result;
    }

    public static ApprovalWorkflow CreateFrom(ApprovalWorkflow workflow, Audit<ApprovalWorkflow> audit, bool isLocked)
    {
        var state = ApprovalWorkflowStateFactory.CreateFrom(workflow.State, isLocked);

        var result = CreateFromDb(
            workflow.Id,
            workflow.Parameters,
            state,
            workflow.ApplicationEvents,
            audit);

        return result;
    }

    public static ApprovalWorkflow CreateFromDb(
        Id<ApprovalWorkflow> id,
        ApprovalWorkflowParameters parameters,
        ApprovalWorkflowState state,
        List<ApprovalWorkflowApplicationEvent> applicationEvents,
        Audit<ApprovalWorkflow> audit)
    {
        var result = new ApprovalWorkflow(id, parameters, state, applicationEvents, audit);

        return result;
    }
}
