using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.GetAll.Contracts;

public sealed record GetAllCountersQueryInternal(Id<EntityDomainInternal> DomainId) : IRequest<GetAllCountersQueryInternalResponse>;
