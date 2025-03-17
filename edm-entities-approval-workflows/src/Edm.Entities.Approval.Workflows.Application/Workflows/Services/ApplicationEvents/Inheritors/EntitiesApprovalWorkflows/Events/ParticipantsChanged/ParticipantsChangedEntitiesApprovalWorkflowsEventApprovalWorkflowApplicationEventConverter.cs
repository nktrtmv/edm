using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Participants;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Events.ParticipantsChanged;

internal static class ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventConverter
{
    internal static ParticipantsChangedEntitiesApprovalWorkflowsEventInternal FromDomain(ApprovalWorkflow workflow)
    {
        var result = new ParticipantsChangedEntitiesApprovalWorkflowsEventInternal(workflow.Parameters.Entity.Id, workflow.Parameters.Entity.DomainId);

        return result;
    }
}
