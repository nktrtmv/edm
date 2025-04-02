using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Keys;

internal static class EntitiesSigningWorkflowsEventsKeyConverter
{
    internal static EntitiesSigningWorkflowsEventsKey FromInternal(EntitiesSigningWorkflowsEventInternal message)
    {
        var key = IdConverterTo.ToString(message.EntityId);

        var result = new EntitiesSigningWorkflowsEventsKey
        {
            Key = key
        };

        return result;
    }
}
