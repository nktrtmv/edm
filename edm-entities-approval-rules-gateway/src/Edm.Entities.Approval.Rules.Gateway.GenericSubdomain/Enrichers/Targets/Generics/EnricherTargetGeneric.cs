namespace Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics;

public abstract class EnricherTargetGeneric<TKey, TValue> : IEnricherTarget where TKey : notnull
{
    public abstract void CollectKeys(List<TKey> keys);
    public abstract void EnrichTargets(Dictionary<TKey, TValue> values);
}
