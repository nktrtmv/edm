using Edm.Document.Searcher.Domain.Documents.Markers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Searcher.Domain.Documents.Factories;

public static class SearchDocumentFactory
{
    public static SearchDocument CreateFrom(
        Id<SearchDocument> id,
        Id<SearchDocumentTemplate> templateId,
        DomainId domainId,
        SearchDocumentAttributeValue[] attributesValues,
        ConcurrencyToken<SearchDocument> concurrencyToken)
    {
        var result = CreateFromDb(id, templateId, domainId, attributesValues, concurrencyToken);

        return result;
    }

    public static SearchDocument CreateFromDb(
        Id<SearchDocument> id,
        Id<SearchDocumentTemplate> templateId,
        DomainId domainId,
        SearchDocumentAttributeValue[] attributesValues,
        ConcurrencyToken<SearchDocument> concurrencyToken)
    {
        var result = new SearchDocument(id, templateId, domainId, attributesValues, concurrencyToken);

        return result;
    }
}
