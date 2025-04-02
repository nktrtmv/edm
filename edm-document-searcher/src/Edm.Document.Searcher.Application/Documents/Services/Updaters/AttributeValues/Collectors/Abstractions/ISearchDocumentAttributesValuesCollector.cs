using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions;

public interface ISearchDocumentAttributesValuesCollector
{
    internal Task Collect(
        SearchDocumentUpdaterContext context,
        List<SearchDocumentAttributeValueInternal> attributesValues,
        CancellationToken cancellationToken);
}
