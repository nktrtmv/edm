using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.Create.Contracts;

public sealed record CreateCounterQueryInternal(
    Id<EntityDomainInternal> DomainId,
    Id<EntityTypeInternal>? EntityTypeId,
    string Name,
    int Value) : IRequest<CreateCounterQueryInternalResponse>;
