using Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Sources;
using Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Targets;

namespace Edm.Document.Searcher.GenericSubdomain.Enrichers;

public class EnrichersContext : List<IEnricherTarget>
{
    public async Task Enrich(IEnumerable<IEnricherSource> sources, CancellationToken cancellationToken)
    {
        IEnricherTarget[] targetsToEnrich = ToArray();

        foreach (IEnricherSource source in sources)
        {
            IEnricherTarget[] enrichedTargets = await source.Enrich(targetsToEnrich, cancellationToken);

            targetsToEnrich = targetsToEnrich.Except(enrichedTargets).ToArray();
        }

        if (targetsToEnrich.Any())
        {
            string[] remainingTargetsTypes = targetsToEnrich.Select(t => t.GetType().Name).Distinct().ToArray();

            string remainingTargetsTypesString = string.Join(", ", remainingTargetsTypes);

            throw new ApplicationException(
                $"Failed to enrich the following targets enrichers (count: {remainingTargetsTypesString.Length}, types: {remainingTargetsTypesString})");
        }
    }
}
