using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Domain.Entities.Counters.Factories;

public static class CounterFactory
{
    public static Counter CreateFromDb(Id<Counter> id, Id<EntityDomain> domainId, Id<EntityType>? entityTypeId, string name, int value)
    {
        var result = new Counter(id, domainId, entityTypeId, name, value);

        return result;
    }

    public static Counter CreateNew(Id<EntityDomain> domainId, Id<EntityType>? entityTypeId, string name, int value)
    {
        Id<Counter> id = IdConverterFrom<Counter>.FromGuid(Guid.NewGuid());

        var result = new Counter(id, domainId, entityTypeId, name, value);

        return result;
    }
}
