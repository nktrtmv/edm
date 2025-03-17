using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Abstractions;

internal interface ISearchDocumentAttributesValuesAdapter
{
    Task<SearchDocumentAttributeValueInternal[]> Adapt(
        SearchDocumentAttributeValueInternal[] attributeValues,
        CancellationToken cancellationToken);
}
