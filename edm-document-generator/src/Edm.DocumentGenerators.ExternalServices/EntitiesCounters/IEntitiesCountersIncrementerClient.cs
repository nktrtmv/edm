using Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Contracts;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesCounters;

public interface IEntitiesCountersIncrementerClient
{
    Task<IncrementEntitiesCountersCommandExternalResponse> Increment(IncrementEntitiesCountersCommandExternal command);
}
