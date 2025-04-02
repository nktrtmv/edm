using Edm.Entities.Counters.Application.Contracts.Counters;

namespace Edm.Entities.Counters.Application.Counters.Queries.GetAll.Contracts;

public sealed record GetAllCountersQueryInternalResponse(CounterInternal[] Counters);
