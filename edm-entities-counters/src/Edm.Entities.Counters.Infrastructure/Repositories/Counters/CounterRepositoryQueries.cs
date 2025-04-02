using Dapper;

using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts;

namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters;

internal static class CounterRepositoryQueries
{
    public static CommandDefinition Increment(string[] countersIds, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
UPDATE counters
SET value = value + 1
WHERE id = ANY(@ids)
AND (SELECT COUNT(*) FROM counters WHERE id = ANY(@ids)) = array_length(@ids, 1)
RETURNING id, value;

",
            new
            {
                ids = countersIds
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetAll(string domainId, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    id,
    domain_id,
    entity_type_id,
    name,
    value
FROM counters
WHERE domain_id = @domain_id;
",
            new
            {
                domain_id = domainId
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Get(string domainId, string id, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
                SELECT
                    id,
                    domain_id,
                    entity_type_id,
                    name,
                    value
                FROM counters
                WHERE domain_id = @domain_id and id = @id;
            """,
            new
            {
                domain_id = domainId, id
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Save(Counter counter, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO counters (id, domain_id, entity_type_id, name, value)
                VALUES (@id, @domain_id, @entity_type_id, @name, @value)
            ON CONFLICT (id) DO UPDATE
            SET
                entity_type_id = excluded.entity_type_id,
                name = excluded.name,
                value = excluded.value
            WHERE
                counters.id = @id
            RETURNING counters.id;
            """,
            new
            {
                id = counter.Id.ToString(),
                domain_id = counter.DomainId.ToString(),
                entity_type_id = counter.EntityTypeId?.ToString() ?? null,
                name = counter.Name,
                value = counter.Value
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition InsertEntityTokenCounters(EntityTokenCounterDb[] entityTokenCounters, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
INSERT INTO entity_token_counters
(
    counter_id,
    entity_token,
    value
)
VALUES
(
    UNNEST(@counter_ids),
    UNNEST(@entity_tokens),
    UNNEST(@values)
);
",
            new
            {
                counter_ids = entityTokenCounters.Select(x => x.CounterId).ToArray(),
                entity_tokens = entityTokenCounters.Select(x => x.EntityToken).ToArray(),
                values = entityTokenCounters.Select(x => x.Value).ToArray()
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetEntityTokenCounters(string[] counterIds, string entityToken, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    counter_id,
    entity_token,
    value
FROM entity_token_counters
WHERE counter_id = ANY(@counter_ids) AND entity_token = @entity_token;
",
            new
            {
                counter_ids = counterIds,
                entity_token = entityToken
            },
            cancellationToken: cancellationToken);
    }
}
