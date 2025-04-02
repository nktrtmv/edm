using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Strings;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues;

internal static class SearchDocumentAttributeValueDbConverter
{
    internal static SearchDocumentAttributeValueDb FromDomain(SearchDocumentAttributeValue attributeValue)
    {
        SearchDocumentAttributeValueDb result = attributeValue switch
        {
            SearchDocumentBooleanAttributeValue v =>
                SearchDocumentBooleanAttributeValueDbConverter.FromDomain(v),

            SearchDocumentDateAttributeValue v =>
                SearchDocumentDateAttributeValueDbConverter.FromDomain(v),

            SearchDocumentNumberAttributeValue v =>
                SearchDocumentNumberAttributeValueDbConverter.FromDomain(v),

            SearchDocumentReferenceAttributeValue v =>
                SearchDocumentReferenceAttributeValueDbConverter.FromDomain(v),

            SearchDocumentStringAttributeValue v =>
                SearchDocumentStringAttributeValueDbConverter.FromDomain(v),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    internal static SearchDocumentAttributeValue ToDomain(SearchDocumentAttributeValueDb attributeValue)
    {
        SearchDocumentAttributeValue result = attributeValue switch
        {
            SearchDocumentBooleanAttributeValueDb v =>
                SearchDocumentBooleanAttributeValueDbConverter.ToDomain(v),

            SearchDocumentDateAttributeValueDb v =>
                SearchDocumentDateAttributeValueDbConverter.ToDomain(v),

            SearchDocumentNumberAttributeValueDb v =>
                SearchDocumentNumberAttributeValueDbConverter.ToDomain(v),

            SearchDocumentReferenceAttributeValueDb v =>
                SearchDocumentReferenceAttributeValueDbConverter.ToDomain(v),

            SearchDocumentStringAttributeValueDb v =>
                SearchDocumentStringAttributeValueDbConverter.ToDomain(v),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }
}
