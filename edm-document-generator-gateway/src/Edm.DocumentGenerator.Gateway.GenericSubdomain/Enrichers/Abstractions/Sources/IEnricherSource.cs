using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Targets;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources;

public interface IEnricherSource
{
    Task<IEnricherTarget[]> Enrich(IEnricherTarget[] targets, CancellationToken cancellationToken);
}
