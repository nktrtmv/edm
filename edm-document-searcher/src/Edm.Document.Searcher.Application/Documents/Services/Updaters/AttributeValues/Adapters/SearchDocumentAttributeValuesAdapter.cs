using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Abstractions;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters;

internal sealed class SearchDocumentAttributeValuesAdapter
{
    public SearchDocumentAttributeValuesAdapter(IEnumerable<ISearchDocumentAttributesValuesAdapter> attributesCollectors)
    {
        Adapters = attributesCollectors.ToArray();
    }

    private ISearchDocumentAttributesValuesAdapter[] Adapters { get; }

    internal async Task<SearchDocumentAttributeValueInternal[]> Adapt(
        SearchDocumentAttributeValueInternal[] attributesValues,
        CancellationToken cancellationToken)
    {
        foreach (ISearchDocumentAttributesValuesAdapter adapter in Adapters)
        {
            attributesValues = await adapter.Adapt(attributesValues, cancellationToken);
        }

        return attributesValues;
    }
}
