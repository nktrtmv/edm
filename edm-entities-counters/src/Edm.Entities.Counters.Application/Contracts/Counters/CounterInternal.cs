using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Application.Contracts.Counters;

public sealed record CounterInternal(Id<CounterInternal> Id, Id<EntityDomainInternal> DomainId, Id<EntityTypeInternal>? EntityTypeId, string Name, int Value);
