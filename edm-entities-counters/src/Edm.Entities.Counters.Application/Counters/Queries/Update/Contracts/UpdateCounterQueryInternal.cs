using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.Update.Contracts;

public sealed record UpdateCounterQueryInternal(
    Id<CounterInternal> CounterId,
    Id<EntityDomainInternal> DomainId,
    Id<EntityTypeInternal>? EntityTypeId,
    string Name,
    int Value) : IRequest<UpdateCounterQueryInternalResponse>;

