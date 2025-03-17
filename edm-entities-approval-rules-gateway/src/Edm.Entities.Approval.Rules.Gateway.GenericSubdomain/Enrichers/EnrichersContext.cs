using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets;

namespace Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;

public class EnrichersContext : List<IEnricherTarget>
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
