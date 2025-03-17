using System.Collections.Concurrent;

using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Enrichers;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.References;

internal abstract class DocumentDelayedReferencesEnricherBase<T> : Enricher<T>
{
    private readonly ConcurrentBag<T> _values = [];

    protected DocumentDelayedReferencesEnricherBase(ReferencesEnricher referenceEnricher, ILogger<DocumentDetailedBffEnricher> logger)
    {
        ReferenceEnricher = referenceEnricher;
        Logger = logger;
    }

    private ReferencesEnricher ReferenceEnricher { get; }
    protected ILogger<DocumentDetailedBffEnricher> Logger { get; }

    public override void Add(T value)
    {
        _values.Add(value);
    }

    public override Task Enrich(CancellationToken cancellationToken)
    {
        if (!_values.IsEmpty)
        {
            throw new InvalidOperationException("Please call DocumentConversionComplete before calling Enrich");
        }

        return Task.CompletedTask;
    }

    public void DocumentConversionComplete(DocumentAttributeValueDetailedBff[] attributeValues, string templateId)
    {
        AddValuesToReferencesEnricher(attributeValues, templateId);

        _values.Clear();
    }

    private void AddValuesToReferencesEnricher(DocumentAttributeValueDetailedBff[] attributeValues, string templateId)
    {
        IEnumerable<ReferenceValueWithType> referenceValueWithTypes = GetReferencesValuesWithTypes(attributeValues, templateId, _values);

        AddRangeToReferencesEnricher(referenceValueWithTypes);
    }

    private void AddRangeToReferencesEnricher(IEnumerable<ReferenceValueWithType> referenceValueWithTypes)
    {
        foreach (var referenceValueWithType in referenceValueWithTypes)
        {
            ReferenceEnricher.Add(referenceValueWithType);
        }
    }

    protected abstract IEnumerable<ReferenceValueWithType> GetReferencesValuesWithTypes(
        IReadOnlyCollection<DocumentAttributeValueDetailedBff> attributeValues,
        string templateId,
        IReadOnlyCollection<T> values);
}
