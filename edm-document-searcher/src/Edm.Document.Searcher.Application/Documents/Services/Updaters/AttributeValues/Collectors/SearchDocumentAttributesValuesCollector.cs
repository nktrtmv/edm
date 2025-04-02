using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors;

internal sealed class SearchDocumentAttributesValuesCollector
{
    public SearchDocumentAttributesValuesCollector(IEnumerable<ISearchDocumentAttributesValuesCollector> attributesCollectors)
    {
        Collectors = attributesCollectors.ToArray();
    }

    private ISearchDocumentAttributesValuesCollector[] Collectors { get; }

    internal async Task<SearchDocumentAttributeValueInternal[]> Collect(SearchDocumentUpdaterContext context, CancellationToken cancellationToken)
    {
        var attributesValues = new List<SearchDocumentAttributeValueInternal>();

        foreach (ISearchDocumentAttributesValuesCollector collector in Collectors)
        {
            await collector.Collect(context, attributesValues, cancellationToken);
        }

        SearchDocumentAttributeValueInternal[] result = attributesValues.ToArray();

        return result;
    }
}
