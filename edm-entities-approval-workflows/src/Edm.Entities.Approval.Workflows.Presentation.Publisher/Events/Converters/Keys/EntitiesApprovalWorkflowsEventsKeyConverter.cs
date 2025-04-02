using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Keys;

internal static class EntitiesApprovalWorkflowsEventsKeyConverter
{
    internal static EntitiesApprovalWorkflowsEventsKey FromDomain(EntitiesApprovalWorkflowsEventInternal request)
    {
        var result = new EntitiesApprovalWorkflowsEventsKey
        {
            Key = request.EntityId
        };

        return result;
    }
}
