namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts;

public sealed record EntityTokenCounterDb(string CounterId, string EntityToken, int Value);
