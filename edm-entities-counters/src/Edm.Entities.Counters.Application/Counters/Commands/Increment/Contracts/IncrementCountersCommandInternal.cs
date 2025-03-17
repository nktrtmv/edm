using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Commands.Increment.Contracts;

public sealed record IncrementCountersCommandInternal(Id<CounterInternal>[] CountersIds, string? EntityToken) : IRequest<IncrementCountersCommandInternalResponse>;
