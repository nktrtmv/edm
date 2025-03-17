using Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Targets;

namespace Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Sources;

public interface IEnricherSource
{
    Task<IEnricherTarget[]> Enrich(IEnricherTarget[] targets, CancellationToken cancellationToken);
}
