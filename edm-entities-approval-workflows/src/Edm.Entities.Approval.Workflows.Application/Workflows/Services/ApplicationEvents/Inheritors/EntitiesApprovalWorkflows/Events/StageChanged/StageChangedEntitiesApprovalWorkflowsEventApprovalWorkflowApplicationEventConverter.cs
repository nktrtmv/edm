using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Stages;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Events.StageChanged;

internal static class StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventConverter
{
    internal static StageChangedEntitiesApprovalWorkflowsEventInternal FromDomain(ApprovalWorkflow workflow)
    {
        var result = new StageChangedEntitiesApprovalWorkflowsEventInternal(workflow.Parameters.Entity.Id, workflow.Parameters.Entity.DomainId);

        return result;
    }
}
