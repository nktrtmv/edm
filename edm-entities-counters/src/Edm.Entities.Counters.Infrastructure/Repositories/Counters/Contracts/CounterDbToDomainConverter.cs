using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Counters.Factories;
using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts;

internal static class CounterDbToDomainConverter
{
    internal static Counter ToDomain(CounterDb counter)
    {
        Id<Counter> id = IdConverterFrom<Counter>.FromString(counter.Id);

        Id<EntityDomain> domainId = IdConverterFrom<EntityDomain>.FromString(counter.DomainId);

        Id<EntityType>? entityTypeId = NullableConverter.Convert(counter.EntityTypeId, IdConverterFrom<EntityType>.FromString);

        Counter result = CounterFactory.CreateFromDb(id, domainId, entityTypeId, counter.Name, counter.Value);

        return result;
    }
}
