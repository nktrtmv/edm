using System.Transactions;

using Dapper;

using Edm.DocumentGenerators.GenericSubdomain.Configuration.Fetchers;
using Edm.DocumentGenerators.Infrastructure.Options;
using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values;
using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;
using Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts;
using Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts.Values;
using Edm.Entities.Counters.Infrastructure.Services;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters;

internal sealed class CounterRepository : ICounterRepository
{
    public CounterRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);
    }

    private DbOptions Options { get; }

    public async Task<CounterValue[]> TryIncrement(Id<Counter>[] countersIds, Id<EntityToken>? entityToken, CancellationToken cancellationToken)
    {
        CounterValue[] result;

        string[] countersIdsDb = countersIds.Select(IdConverterTo.ToString).ToArray();

        if (entityToken is not null)
        {
            result = await TryIncrementAndUpdateEntityTokenCounters(countersIdsDb, entityToken.Value, cancellationToken);

            return result;
        }

        await using NpgsqlConnection connection = await GetAndOpenConnection();

        IEnumerable<CounterValueDb> countersValuesDb = await connection.QueryAsync<CounterValueDb>(CounterRepositoryQueries.Increment(countersIdsDb, cancellationToken));

        result = countersValuesDb.Select(CounterValueDbToDomainConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<Counter[]> GetAll(Id<EntityDomain> domainId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var domainIdDb = IdConverterTo.ToString(domainId);

        IEnumerable<CounterDb> countersDb = await connection.QueryAsync<CounterDb>(CounterRepositoryQueries.GetAll(domainIdDb, cancellationToken));

        Counter[] result = countersDb.Select(CounterDbToDomainConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<Counter> GetByIdRequired(string domainId, string id, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var countersDb = await connection.QuerySingleOrDefaultAsync<CounterDb>(CounterRepositoryQueries.Get(domainId, id, cancellationToken));

        if (countersDb is null)
        {
            throw new ApplicationException($"Counter {id} not found");
        }

        Counter result = CounterDbToDomainConverter.ToDomain(countersDb);

        return result;
    }

    public async Task Upsert(Counter counter, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        await connection.QueryAsync(CounterRepositoryQueries.Save(counter, cancellationToken));
    }

    private async Task<CounterValue[]> TryIncrementAndUpdateEntityTokenCounters(
        string[] countersIds,
        Id<EntityToken> entityToken,
        CancellationToken cancellationToken)
    {
        var entityTokenDb = IdConverterTo.ToString(entityToken);

        using TransactionScope scope = TransactionHelper.CreateTransaction();
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        IEnumerable<EntityTokenCounterDb> existedEntityTokenCounters =
            (await connection.QueryAsync<EntityTokenCounterDb>(CounterRepositoryQueries.GetEntityTokenCounters(countersIds, entityTokenDb, cancellationToken)))
            .ToArray();

        string[] notExistedEntityTokenCounters = countersIds.Except(existedEntityTokenCounters.Select(c => c.CounterId)).ToArray();

        IEnumerable<CounterValueDb> incrementedNewCounterValues =
            (await connection.QueryAsync<CounterValueDb>(CounterRepositoryQueries.Increment(notExistedEntityTokenCounters, cancellationToken)))
            .ToArray();

        EntityTokenCounterDb[] incrementedNewEntityTokenCounters =
            incrementedNewCounterValues.Select(v => EntityTokenCounterDbConverter.FromCounterValueDb(v, entityTokenDb)).ToArray();

        await connection.QueryAsync(CounterRepositoryQueries.InsertEntityTokenCounters(incrementedNewEntityTokenCounters, cancellationToken));

        scope.Complete();

        CounterValue[] result = existedEntityTokenCounters.Select(EntityTokenCounterDbConverter.ToCounterValueDb)
            .Concat(incrementedNewCounterValues)
            .Select(CounterValueDbToDomainConverter.ToDomain)
            .ToArray();

        return result;
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
