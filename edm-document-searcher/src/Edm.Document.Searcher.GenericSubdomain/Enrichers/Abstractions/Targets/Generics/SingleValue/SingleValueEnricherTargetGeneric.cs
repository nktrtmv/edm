namespace Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Targets.Generics.SingleValue;

public abstract class SingleValueEnricherTargetGeneric<TKey, TValue> : EnricherTargetGeneric<TKey, TValue> where TKey : notnull
{
    protected abstract TKey GetKey();

    protected abstract void EnrichTarget(TValue value);

    public override void CollectKeys(List<TKey> keys)
    {
        TKey key = GetKey();

        keys.Add(key);
    }

    public override void EnrichTargets(Dictionary<TKey, TValue> values)
    {
        TKey key = GetKey();

        TValue? value = values.GetValueOrDefault(key);

        if (value is null)
        {
            return;
        }

        EnrichTarget(value);
    }
}
