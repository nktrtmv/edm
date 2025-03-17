using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Abstractions.
    SynchronousSingle;

internal abstract class SynchronousSingleSearchDocumentAttributesValuesAdapter : ISearchDocumentAttributesValuesAdapter
{
    Task<SearchDocumentAttributeValueInternal[]> ISearchDocumentAttributesValuesAdapter.Adapt(
        SearchDocumentAttributeValueInternal[] attributesValues,
        CancellationToken cancellationToken)
    {
        SearchDocumentAttributeValueInternal[] result = attributesValues
            .Select(Adapt)
            .ToArray();

        return Task.FromResult(result);
    }

    protected abstract SearchDocumentAttributeValueInternal Adapt(SearchDocumentAttributeValueInternal attributeValue);
}
