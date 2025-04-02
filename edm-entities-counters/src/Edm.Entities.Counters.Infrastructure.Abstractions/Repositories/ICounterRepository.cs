using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values;
using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;

public interface ICounterRepository
{
    Task<CounterValue[]> TryIncrement(Id<Counter>[] countersIds, Id<EntityToken>? entityToken, CancellationToken cancellationToken);
    Task<Counter[]> GetAll(Id<EntityDomain> domainId, CancellationToken cancellationToken);
    Task<Counter> GetByIdRequired(string id, string domainId, CancellationToken cancellationToken);
    Task Upsert(Counter counter, CancellationToken cancellationToken);
}
