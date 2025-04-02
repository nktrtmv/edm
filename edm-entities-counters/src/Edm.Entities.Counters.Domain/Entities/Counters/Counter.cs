using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Domain.Entities.Counters;

public sealed class Counter
{
    internal Counter(Id<Counter> id, Id<EntityDomain> domainId, Id<EntityType>? entityTypeId, string name, int value)
    {
        Id = id;
        DomainId = domainId;
        EntityTypeId = entityTypeId;
        Name = name;
        Value = value;
    }

    public Id<Counter> Id { get; }
    public Id<EntityDomain> DomainId { get; }
    public Id<EntityType>? EntityTypeId { get; private set; }
    public string Name { get; private set; }
    public int Value { get; private set; }

    public void Update(Id<EntityType>? entityTypeId, string name, int value)
    {
        EntityTypeId = entityTypeId;
        Name = name;
        Value = value;
    }
}
