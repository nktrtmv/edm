using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Stages;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Values.StageChanged;

internal static class StageChangedEntitiesApprovalWorkflowsEventConverter
{
    internal static EntitiesApprovalWorkflowsEventsValue FromDomain(
        StageChangedEntitiesApprovalWorkflowsEventInternal request,
        string domainId)
    {
        var asStageChanged = new StageChangedEntitiesApprovalWorkflowsEvent
        {
            EntityId = request.EntityId
        };

        var result = new EntitiesApprovalWorkflowsEventsValue
        {
            DomainId = domainId,
            AsStageChanged = asStageChanged
        };

        return result;
    }
}
