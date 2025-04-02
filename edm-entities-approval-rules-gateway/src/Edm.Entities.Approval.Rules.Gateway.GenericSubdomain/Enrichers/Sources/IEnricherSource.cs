using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets;

namespace Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;

public interface IEnricherSource
{
    Task<IEnricherTarget[]> Enrich(IEnricherTarget[] targets, CancellationToken cancellationToken);
}
