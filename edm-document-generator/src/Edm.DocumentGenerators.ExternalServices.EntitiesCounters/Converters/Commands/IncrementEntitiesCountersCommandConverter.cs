using Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Converters.Commands;

internal static class IncrementEntitiesCountersCommandConverter
{
    internal static IncrementEntitiesCountersCommand FromExternal(IncrementEntitiesCountersCommandExternal command)
    {
        IEnumerable<string> entitiesCountersIds = command.EntitiesCountersIds.Select(IdConverterTo.ToString);

        var result = new IncrementEntitiesCountersCommand
        {
            EntitiesCountersIds = { entitiesCountersIds },
            EntityToken = command.EntityToken
        };

        return result;
    }
}
