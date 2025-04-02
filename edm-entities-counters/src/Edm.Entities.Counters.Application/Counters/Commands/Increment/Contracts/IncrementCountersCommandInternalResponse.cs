using Edm.Entities.Counters.Application.Contracts.Counters.Contracts;

namespace Edm.Entities.Counters.Application.Counters.Commands.Increment.Contracts;

public sealed record IncrementCountersCommandInternalResponse(CounterValueInternal[] CountersValues);
