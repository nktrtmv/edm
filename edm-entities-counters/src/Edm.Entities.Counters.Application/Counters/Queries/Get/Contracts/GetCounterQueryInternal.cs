using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.Get.Contracts;

public sealed record GetCounterQueryInternal(Id<EntityDomainInternal> DomainId, Id<CounterInternal> CounterId) : IRequest<GetCounterQueryInternalResponse>;

