using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts;

internal static class SearchDocumentDbFromDomainConverter
{
    internal static SearchDocumentDb FromDomain(SearchDocument document)
    {
        var id = IdConverterTo.ToString(document.Id);

        var templateId = IdConverterTo.ToString(document.TemplateId);

        var attributesValues = SearchDocumentAttributesValuesDbConverter.FromDomain(document.AttributesValues);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(document.ConcurrencyToken);

        var result = new SearchDocumentDb
        {
            DomainId = document.DomainId.Value,
            Id = id,
            TemplateId = templateId,
            AttributesValues = attributesValues,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
