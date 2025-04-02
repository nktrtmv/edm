using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.StageChanged;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Events.StageChanged;

internal static class StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter
{
    internal static EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb FromDomain(
        StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent applicationEvent)
    {
        var asStageChanged = new StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb();

        var result = new EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb
        {
            AsStageChanged = asStageChanged
        };

        return result;
    }

    internal static EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent ToDomain(
        StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb applicationEvent)
    {
        var result = new StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent();

        return result;
    }
}
