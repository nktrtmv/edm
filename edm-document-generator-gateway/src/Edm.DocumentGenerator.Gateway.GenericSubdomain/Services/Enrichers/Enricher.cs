namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Enrichers;

public abstract class Enricher<T>
{
    public abstract void Add(T value);
    public abstract Task Enrich(CancellationToken cancellationToken);
}
