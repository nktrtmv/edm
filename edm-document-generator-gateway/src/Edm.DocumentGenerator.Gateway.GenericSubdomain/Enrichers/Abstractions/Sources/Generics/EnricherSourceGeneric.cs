using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Targets;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Targets.Generics;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources.Generics;

public abstract class EnricherSourceGeneric<TClient, TKey, TValue> : IEnricherSource
    where TKey : notnull
{
    protected EnricherSourceGeneric(TClient client, ILogger<EnricherSourceGeneric<TClient, TKey, TValue>> logger)
    {
        Client = client;
        Logger = logger;
    }

    protected TClient Client { get; }
    protected ILogger<EnricherSourceGeneric<TClient, TKey, TValue>> Logger { get; }

    async Task<IEnricherTarget[]> IEnricherSource.Enrich(IEnricherTarget[] targets, CancellationToken cancellationToken)
    {
        EnricherTargetGeneric<TKey, TValue>[] enriched = targets.OfType<EnricherTargetGeneric<TKey, TValue>>().ToArray();

        if (enriched.Length == 0)
        {
            return [];
        }

        await Enrich(enriched, cancellationToken);

        IEnricherTarget[] result = enriched.Cast<IEnricherTarget>().ToArray();

        return result;
    }

    protected abstract Task Enrich(EnricherTargetGeneric<TKey, TValue>[] enrichers, CancellationToken cancellationToken);

    protected static TKey[] CollectDistinctKeys(EnricherTargetGeneric<TKey, TValue>[] targets)
    {
        var keys = new List<TKey>();

        foreach (EnricherTargetGeneric<TKey, TValue> target in targets)
        {
            target.CollectKeys(keys);
        }

        TKey[] result = keys.Distinct().ToArray();

        return result;
    }

    protected void EnrichTargetModels(EnricherTargetGeneric<TKey, TValue>[] targets, Dictionary<TKey, TValue> values)
    {
        foreach (EnricherTargetGeneric<TKey, TValue> target in targets)
        {
            try
            {
                target.EnrichTargets(values);
            }
            catch (Exception e)
            {
                var keys = string.Join(", ", values.Keys);

                Logger.LogError(
                    e,
                    """
                    ERROR: ⭕️ Failed to enrich.
                    Enricher: {Enricher}
                    Keys: [{Keys}]
                    """,
                    target,
                    keys);
            }
        }
    }
}
