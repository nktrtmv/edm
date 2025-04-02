namespace Edm.Document.Searcher.GenericSubdomain.Services.Enrichers;

public abstract class Enricher<T>
{
    public abstract void Add(T value);
    public abstract Task Enrich(CancellationToken cancellationToken);
}
