using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.Factories;
using Edm.Document.Searcher.Domain.Documents.Markers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.Documents.Builders;

internal static class SearchDocumentBuilder
{
    internal static SearchDocument Build(
        DocumentExternal document,
        SearchDocument? originalDocument,
        SearchDocumentAttributeValueInternal[] adaptedAttributesValues)
    {
        var attributesValues =
            adaptedAttributesValues.Select(SearchDocumentAttributeValueInternalToDomainConverter.ToDomain).ToArray();

        Id<SearchDocument> id = IdConverterFrom<SearchDocument>.From(document.Id);

        Id<SearchDocumentTemplate> templateId = IdConverterFrom<SearchDocumentTemplate>.From(document.TemplateId);

        var domainId = DomainId.Parse(document.DomainId);

        var concurrencyToken = originalDocument?.ConcurrencyToken ?? ConcurrencyToken<SearchDocument>.Empty;

        var result = SearchDocumentFactory.CreateFrom(
            id,
            templateId,
            domainId,
            attributesValues,
            concurrencyToken);

        return result;
    }
}
