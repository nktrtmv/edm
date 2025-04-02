using System.Collections.Concurrent;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Enrichers;

public abstract class GenericEnricher<TKey, TValue, TFullValue> : Enricher<TValue> where TKey : notnull
{
    private readonly ConcurrentBag<TValue> _values = new ConcurrentBag<TValue>();
    protected readonly ILogger<GenericEnricher<TKey, TValue, TFullValue>> Logger;

    protected GenericEnricher(ILogger<GenericEnricher<TKey, TValue, TFullValue>> logger)
    {
        Logger = logger;
    }

    public override void Add(TValue value)
    {
        _values.Add(value);
    }

    public sealed override async Task Enrich(CancellationToken cancellationToken)
    {
        TValue[] notNullValues = GetNotNullValues(_values, this, Logger);

        TKey[] keys = notNullValues.Select(GetKey).Distinct().ToArray();

        TFullValue[] fullValues = Array.Empty<TFullValue>();

        try
        {
            fullValues = await GetFullValues(keys, cancellationToken);
        }
        catch (Exception exception)
        {
            Logger.LogError(exception, "Error while trying to enrich data");
        }

        Dictionary<TKey, TFullValue> fullValuesById = fullValues.DistinctBy(GetKeyFromFullValue).ToDictionary(GetKeyFromFullValue);

        foreach (var value in _values.ToList())
        {
            if (fullValuesById.TryGetValue(GetKey(value), out var fullValue))
            {
                EnrichValue(value, fullValue);
            }
        }

        TKey[] keysLeft = keys.Except(fullValuesById.Keys).ToArray();

        if (keysLeft.Any())
        {
            var keysLeftAsString = string.Join(", ", keysLeft);
            Logger.LogError("ERROR: ❌ Enricher ({@Enricher}). Values for the following keys not found {@KeysLeftAsString}:", ToString(), keysLeftAsString);
        }
    }

    private static TValue[] GetNotNullValues(
        IReadOnlyCollection<TValue> values,
        GenericEnricher<TKey, TValue, TFullValue> enricher,
        ILogger<GenericEnricher<TKey, TValue, TFullValue>> logger)
    {
        TValue[] notNullValues = values.Where(v => v is not null).ToArray();

        if (notNullValues.Length != values.Count)
        {
            logger.LogError(
                "ERROR: ❌ Enricher ({@Enricher}). Detected null values: {NullCount} of {AllCount} values are null",
                enricher.ToString(),
                values.Count - notNullValues.Length,
                values.Count);
        }

        return notNullValues;
    }

    protected abstract void EnrichValue(TValue value, TFullValue fullValue);

    protected abstract TKey GetKey(TValue value);
    protected abstract TKey GetKeyFromFullValue(TFullValue value);
    protected abstract Task<TFullValue[]> GetFullValues(TKey[] keys, CancellationToken cancellationToken);

    public override string ToString()
    {
        return $"Enricher type: {GetType().Name}";
    }
}
