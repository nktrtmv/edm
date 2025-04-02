using System.Collections.Concurrent;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Targets;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers;

public class EnrichersContext : ConcurrentBag<IEnricherTarget>
{
    public async Task Enrich(IEnumerable<IEnricherSource> sources, CancellationToken cancellationToken)
    {
        IEnricherTarget[] targetsToEnrich = ToArray();

        foreach (var source in sources)
        {
            IEnricherTarget[] enrichedTargets = await source.Enrich(targetsToEnrich, cancellationToken);

            targetsToEnrich = targetsToEnrich.Except(enrichedTargets).ToArray();
        }

        if (targetsToEnrich.Any())
        {
            string[] remainingTargetsTypes = targetsToEnrich.Select(t => t.GetType().Name).Distinct().ToArray();

            var remainingTargetsTypesString = string.Join(", ", remainingTargetsTypes);

            throw new ApplicationException(
                $"Failed to enrich the following targets enrichers (count: {remainingTargetsTypesString.Length}, types: {remainingTargetsTypesString})");
        }
    }
}
