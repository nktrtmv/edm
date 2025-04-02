using JetBrains.Annotations;

namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts;

[UsedImplicitly]
internal sealed class CounterDb
{
    internal required string Id { get; init; }
    internal required string DomainId { get; init; }
    internal string? EntityTypeId { get; init; }
    internal required string Name { get; init; }
    internal required int Value { get; init; }
}
