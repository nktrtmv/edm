using System.Text.Json;

using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Boolean;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Date;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Number;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Reference;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.String;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors.JsonFields;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors;

internal static class SearchDocumentsQueryMatchFilterDbConverter
{
    internal static string FromDomain(SearchDocumentsQueryMatchFilter filter)
    {
        string[] values = filter.Values.Select(ToValue).ToArray();
        string[] valuesTypes = filter.Values.Select(ToValueType).ToArray();

        var filters = new List<string>();

        foreach (int registryRoleId in filter.RegistryRolesIds)
        {
            for (var i = 0; i < filter.Values.Length; i++)
            {
                string filterDb = ToFilter(registryRoleId, values[i], valuesTypes[i]);

                filters.Add(filterDb);
            }
        }

        string result = string.Join(" OR ", filters);

        return result;
    }

    private static string ToValue(SearchDocumentsQueryFilterValue value)
    {
        string result = value switch
        {
            SearchDocumentsQueryFilterBooleanValue v => v.Value.ToString().ToLower(),
            SearchDocumentsQueryFilterDateValue v => UtcDateTimeConverterTo.ToTicks(v.Value).ToString(),
            SearchDocumentsQueryFilterNumberValue v => NumberConverterTo.ToString(v.Value),
            SearchDocumentsQueryFilterReferenceValue v => JsonSerializer.Serialize(v.Value),
            SearchDocumentsQueryFilterStringValue v => JsonSerializer.Serialize(v.Value),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }

    private static string ToValueType(SearchDocumentsQueryFilterValue value)
    {
        string result = value switch
        {
            SearchDocumentsQueryFilterBooleanValue => nameof(SearchDocumentAttributesValuesDb.BooleanValues),
            SearchDocumentsQueryFilterDateValue => nameof(SearchDocumentAttributesValuesDb.DateValues),
            SearchDocumentsQueryFilterNumberValue => nameof(SearchDocumentAttributesValuesDb.NumberValues),
            SearchDocumentsQueryFilterReferenceValue => nameof(SearchDocumentAttributesValuesDb.ReferenceValues),
            SearchDocumentsQueryFilterStringValue => nameof(SearchDocumentAttributesValuesDb.StringValues),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }

    private static string ToFilter(int registryRoleId, string matchValue, string valueType)
    {
        var result =
            $"{SearchDocumentJsonFieldAlias.AttributesValues} -> '{valueType}' @> '[{{\"{SearchDocumentJsonFieldAlias.RegistryRoleId}\": {registryRoleId}, \"{SearchDocumentJsonFieldAlias.Values}\": [{matchValue}]}}]'::jsonb";

        return result;
    }
}
