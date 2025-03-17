using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Date;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Number;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors.JsonFields;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors;

internal static class SearchDocumentsQueryRangeFilterDbConverter
{
    internal static string FromDomain(SearchDocumentsQueryRangeFilter filter)
    {
        int[] registryRolesIds = filter.RegistryRolesIds;

        string startValue = ToValue(filter.StartValue);
        string endValue = ToValue(filter.EndValue);
        string valueType = ToValueType(filter);

        string[] filters = registryRolesIds.Select(id => CreateFrom(id, startValue, endValue, valueType)).ToArray();

        string result = string.Join(" OR ", filters);

        return result;
    }

    private static string ToValue(SearchDocumentsQueryFilterValue value)
    {
        string result = value switch
        {
            SearchDocumentsQueryFilterDateValue v => UtcDateTimeConverterTo.ToTicks(v.Value).ToString(),
            SearchDocumentsQueryFilterNumberValue v => NumberConverterTo.ToString(v.Value),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }

    private static string ToValueType(SearchDocumentsQueryRangeFilter filter)
    {
        if (filter.StartValue.GetType() != filter.EndValue.GetType())
        {
            throw new ApplicationException("Start and end values of filter cant be of different types.");
        }

        string result = filter.StartValue switch
        {
            SearchDocumentsQueryFilterDateValue => nameof(SearchDocumentAttributesValuesDb.DateValues),
            SearchDocumentsQueryFilterNumberValue => nameof(SearchDocumentAttributesValuesDb.NumberValues),
            _ => throw new ArgumentTypeOutOfRangeException(filter.StartValue)
        };

        return result;
    }

    private static string CreateFrom(int registryRoleId, string startValue, string endValue, string valueType)
    {
        var result =
            $"{SearchDocumentJsonFieldAlias.AttributesValues} @? '$.{valueType}[*] ? (@.\"{SearchDocumentJsonFieldAlias.RegistryRoleId}\" == {registryRoleId} && @.\"{SearchDocumentJsonFieldAlias.Values}\"[*] >= {startValue} && @.\"{SearchDocumentJsonFieldAlias.Values}\"[*] <= {endValue})'";

        return result;
    }
}
