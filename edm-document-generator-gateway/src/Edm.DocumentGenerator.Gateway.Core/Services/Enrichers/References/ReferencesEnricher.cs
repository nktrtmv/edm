using System.Collections.Concurrent;

using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Enrichers;

namespace Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

public sealed class ReferencesEnricher(ILogger<ReferencesByTypeEnricher> logger, GetReferencesTypeValuesSearchService searchService)
    : Enricher<ReferenceValueWithType>
{
    private readonly ConcurrentDictionary<(string ReferenceType, string TemplateId), ReferencesByTypeEnricher> _enrichersByTypeAndTemplate =
        new ConcurrentDictionary<(string ReferenceType, string TemplateId), ReferencesByTypeEnricher>();

    public override void Add(ReferenceValueWithType value)
    {
        var (referenceType, template, _) = value.Key;

        (string referenceType, string template) key = (referenceType, template);

        if (!_enrichersByTypeAndTemplate.TryGetValue(key, out var nestedEnricher))
        {
            nestedEnricher = new ReferencesByTypeEnricher(value.Key, searchService, logger);
            _enrichersByTypeAndTemplate[key] = nestedEnricher;
        }

        nestedEnricher.Add(value.Value);
    }

    public override async Task Enrich(CancellationToken cancellationToken)
    {
        IEnumerable<Task> enrichersByTypeTasks = _enrichersByTypeAndTemplate
            .GroupBy(k => k.Key.ReferenceType, v => v.Value)
            .Select(group => EnrichByType(group, cancellationToken));

        await Task.WhenAll(enrichersByTypeTasks);
    }

    private async Task EnrichByType(IEnumerable<ReferencesByTypeEnricher> enrichersByType, CancellationToken cancellationToken)
    {
        foreach (var enricher in enrichersByType)
        {
            await enricher.Enrich(cancellationToken);
        }
    }
}
