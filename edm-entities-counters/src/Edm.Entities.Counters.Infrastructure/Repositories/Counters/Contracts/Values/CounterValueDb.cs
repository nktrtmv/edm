using JetBrains.Annotations;

namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts.Values;

[UsedImplicitly]
internal sealed class CounterValueDb
{
    internal required string Id { get; init; }
    internal required int Value { get; init; }
}
