using System.Text.Json;
using System.Text.RegularExpressions;

using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.String;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors.JsonFields;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors;

internal static class SearchDocumentsQueryContainsFilterDbConverter
{
    internal static string FromDomain(SearchDocumentsQueryContainsFilter filter)
    {
        var filters = new List<string>();

        foreach (int registryRoleId in filter.RegistryRolesIds)
        {
            foreach (SearchDocumentsQueryFilterValue t in filter.Values)
            {
                string value = ToValue(t);

                string valueType = ToValueType(t);

                string filterDb = CreateFrom(registryRoleId, value, valueType);

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
            SearchDocumentsQueryFilterStringValue v => v.Value,
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }

    private static string ToValueType(SearchDocumentsQueryFilterValue value)
    {
        string result = value switch
        {
            SearchDocumentsQueryFilterStringValue => nameof(SearchDocumentAttributesValuesDb.StringValues),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }

    private static string CreateFrom(int registryRoleId, string matchValue, string valueType)
    {
        matchValue = Regex.Escape(matchValue);

        string result =
            $"{SearchDocumentJsonFieldAlias.AttributesValues} @? '$.{valueType}[*] " +
            $"? (@.\"{SearchDocumentJsonFieldAlias.RegistryRoleId}\" == {registryRoleId} && @.\"{SearchDocumentJsonFieldAlias.Values}\"[*] like_regex {JsonSerializer.Serialize($".*?({matchValue}).*?")} flag {JsonSerializer.Serialize("i")})'";

        return result;
    }
}
