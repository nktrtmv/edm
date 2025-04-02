using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts.Factories;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Documents.Builders;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters;

internal sealed class SearchDocumentUpdater
{
    public SearchDocumentUpdater(
        SearchDocumentUpdaterContextFactory context,
        SearchDocumentAttributesValuesCollector collector,
        SearchDocumentAttributeValuesAdapter adapter)
    {
        Context = context;
        Collector = collector;
        Adapter = adapter;
    }

    private SearchDocumentUpdaterContextFactory Context { get; }
    private SearchDocumentAttributesValuesCollector Collector { get; }
    private SearchDocumentAttributeValuesAdapter Adapter { get; }

    internal async Task<SearchDocument> Update(
        Id<SearchDocument> documentId,
        SearchDocument? originalDocument,
        CancellationToken cancellationToken)
    {
        var context = await Context.Create(documentId, originalDocument, cancellationToken);

        SearchDocumentAttributeValueInternal[] collectedAttributesValues = await Collector.Collect(context, cancellationToken);

        SearchDocumentAttributeValueInternal[] adaptedAttributesValues = await Adapter.Adapt(collectedAttributesValues, cancellationToken);

        var result = SearchDocumentBuilder.Build(context.Document, originalDocument, adaptedAttributesValues);

        return result;
    }
}
