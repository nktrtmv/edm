using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Application.Counters.Queries.Update.Contracts;

public sealed record UpdateCounterQueryInternalResponse(Id<CounterInternal> Id);
