using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources.Generics.SingleKey;

public abstract class SingleKeyEnricherSourceGeneric<TClient, TKey, TValue>
    : EnricherSourceGeneric<TClient, TKey, TValue>
    where TKey : notnull
{
    protected SingleKeyEnricherSourceGeneric(TClient client, ILogger<EnricherSourceGeneric<TClient, TKey, TValue>> logger) : base(client, logger)
    {
    }

    protected abstract Task<Dictionary<TKey, TValue>> GetValues(TKey[] keys, CancellationToken cancellationToken);

    protected override async Task Enrich(EnricherTargetGeneric<TKey, TValue>[] enrichers, CancellationToken cancellationToken)
    {
        TKey[] keys = CollectDistinctKeys(enrichers);

        Dictionary<TKey, TValue> values = await GetValues(keys, cancellationToken);

        TKey[] missingKeys = keys.Except(values.Keys).ToArray();

        if (missingKeys.Any())
        {
            var missingKeysString = string.Join(", ", missingKeys);

            Logger.LogError(
                """
                ERROR: ⭕️ Failed to enrich ({Count}) values.
                Enricher: {@Enricher}
                Keys: [{Keys}]
                """,
                missingKeys.Length,
                GetType().Name,
                missingKeysString);
        }

        EnrichTargetModels(enrichers, values);
    }
}
