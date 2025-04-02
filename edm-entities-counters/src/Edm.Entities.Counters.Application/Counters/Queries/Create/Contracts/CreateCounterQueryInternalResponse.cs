using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Application.Counters.Queries.Create.Contracts;

public sealed record CreateCounterQueryInternalResponse(Id<CounterInternal> Id);
