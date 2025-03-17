using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.Factories;
using Edm.Document.Searcher.Domain.Documents.Markers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts;

internal static class SearchDocumentDbToDomainConverter
{
    internal static SearchDocument ToDomain(SearchDocumentDb document)
    {
        Id<SearchDocument> id = IdConverterFrom<SearchDocument>.FromString(document.Id);

        Id<SearchDocumentTemplate> templateId = IdConverterFrom<SearchDocumentTemplate>.FromString(document.TemplateId);

        var domainId = DomainId.Parse(document.DomainId);

        SearchDocumentAttributeValueDb[] attributesValuesDb = SearchDocumentAttributesValuesDbConverter.FromJson(document.AttributesValues);

        SearchDocumentAttributeValue[] attributesValues = attributesValuesDb.Select(SearchDocumentAttributeValueDbConverter.ToDomain).ToArray();

        ConcurrencyToken<SearchDocument> concurrencyToken =
            ConcurrencyTokenConverterFrom<SearchDocument>.FromUnspecifiedUtcDateTime(document.ConcurrencyToken);

        var result = SearchDocumentFactory.CreateFromDb(id, templateId, domainId, attributesValues, concurrencyToken);

        return result;
    }
}
