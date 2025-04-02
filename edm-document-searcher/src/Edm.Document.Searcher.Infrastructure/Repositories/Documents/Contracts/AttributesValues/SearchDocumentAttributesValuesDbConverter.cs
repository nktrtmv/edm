using System.Text.Json;

using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Strings;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;

internal static class SearchDocumentAttributesValuesDbConverter
{
    internal static SearchDocumentAttributeValueDb[] FromJson(string data)
    {
        var dataDb = JsonSerializer.Deserialize<SearchDocumentAttributesValuesDb>(data)!;

        SearchDocumentAttributeValueDb[] result = Array.Empty<SearchDocumentAttributeValueDb>()
            .Concat(dataDb.BooleanValues)
            .Concat(dataDb.DateValues)
            .Concat(dataDb.NumberValues)
            .Concat(dataDb.ReferenceValues)
            .Concat(dataDb.StringValues)
            .ToArray();

        return result;
    }

    internal static string FromDomain(SearchDocumentAttributeValue[] attributesValues)
    {
        SearchDocumentAttributeValueDb[] values = attributesValues.Select(SearchDocumentAttributeValueDbConverter.FromDomain).ToArray();

        SearchDocumentBooleanAttributeValueDb[] booleanValues = values.OfType<SearchDocumentBooleanAttributeValueDb>().ToArray();
        SearchDocumentDateAttributeValueDb[] dateValues = values.OfType<SearchDocumentDateAttributeValueDb>().ToArray();
        SearchDocumentNumberAttributeValueDb[] numberValues = values.OfType<SearchDocumentNumberAttributeValueDb>().ToArray();
        SearchDocumentReferenceAttributeValueDb[] referenceValues = values.OfType<SearchDocumentReferenceAttributeValueDb>().ToArray();
        SearchDocumentStringAttributeValueDb[] stringValues = values.OfType<SearchDocumentStringAttributeValueDb>().ToArray();

        var data = new SearchDocumentAttributesValuesDb
        {
            BooleanValues = booleanValues,
            DateValues = dateValues,
            NumberValues = numberValues,
            ReferenceValues = referenceValues,
            StringValues = stringValues
        };

        string result = JsonSerializer.Serialize(data);

        return result;
    }
}
