using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters.Orders;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters.ValuesTypes;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors.JsonFields;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.SortParameters;

internal static class SearchDocumentSortParametersDbConverter
{
    internal static string FromDomain(SearchDocumentSortParameters sortParameters)
    {
        int registryRoleId = sortParameters.RegistryRoleId;

        string sortOrder = GetSortOrder(sortParameters.SortOrder);

        string sortValueType = GetSortFieldType(sortParameters.SortValueType);

        string postgresValueType = GetPostgresValueType(sortParameters.SortValueType);

        string postgresAggregateFunction = GetPostgresAggregateFunction(sortParameters.SortOrder);

        string result = GetSortParameters(
            registryRoleId,
            sortOrder,
            sortValueType,
            postgresValueType,
            postgresAggregateFunction);

        return result;
    }

    private static string GetSortParameters(
        int registryRoleId,
        string sortOrder,
        string sortValueType,
        string postgresValueType,
        string postgresAggregateFunction)
    {
        var result =
            $"""
             ORDER BY CASE
                          WHEN EXISTS (SELECT 1
                                       FROM jsonb_array_elements({SearchDocumentJsonFieldAlias.AttributesValues}->'{sortValueType}') vals
                                       WHERE vals->>'{SearchDocumentJsonFieldAlias.RegistryRoleId}' = '{registryRoleId}')
                              THEN (SELECT {postgresAggregateFunction}(value::{postgresValueType})
                                    FROM jsonb_array_elements(
                                                 (SELECT value->'{SearchDocumentJsonFieldAlias.Values}'
                                                  FROM jsonb_array_elements({SearchDocumentJsonFieldAlias.AttributesValues}->'{sortValueType}')
                                                  WHERE value->>'{SearchDocumentJsonFieldAlias.RegistryRoleId}' = '{registryRoleId}')
                                         ) AS value
                          )
                          END {sortOrder} NULLS LAST
             """;

        return result;
    }

    private static string GetPostgresValueType(SearchDocumentSortValueType sortValueType)
    {
        string result = sortValueType switch
        {
            SearchDocumentSortValueType.Date => "bigint",
            SearchDocumentSortValueType.Number => "bigint",
            SearchDocumentSortValueType.String => "text",
            SearchDocumentSortValueType.Boolean => "boolean::int",
            SearchDocumentSortValueType.Reference => "text",
            _ => throw new ArgumentTypeOutOfRangeException(sortValueType)
        };

        return result;
    }

    private static string GetPostgresAggregateFunction(SearchDocumentSortOrder sortOrder)
    {
        string result = sortOrder switch
        {
            SearchDocumentSortOrder.Ascending => "MIN",

            SearchDocumentSortOrder.Descending => "MAX",

            _ => throw new ArgumentTypeOutOfRangeException(sortOrder)
        };

        return result;
    }

    private static string GetSortFieldType(SearchDocumentSortValueType sortValueType)
    {
        string result = sortValueType switch
        {
            SearchDocumentSortValueType.Date => nameof(SearchDocumentAttributesValuesDb.DateValues),

            SearchDocumentSortValueType.Number => nameof(SearchDocumentAttributesValuesDb.NumberValues),

            SearchDocumentSortValueType.String => nameof(SearchDocumentAttributesValuesDb.StringValues),

            SearchDocumentSortValueType.Boolean => nameof(SearchDocumentAttributesValuesDb.BooleanValues),

            SearchDocumentSortValueType.Reference => nameof(SearchDocumentAttributesValuesDb.ReferenceValues),

            _ => throw new ArgumentTypeOutOfRangeException(sortValueType)
        };

        return result;
    }

    private static string GetSortOrder(SearchDocumentSortOrder sortOrder)
    {
        string result = sortOrder switch
        {
            SearchDocumentSortOrder.Ascending => "ASC",

            SearchDocumentSortOrder.Descending => "DESC",

            _ => throw new ArgumentTypeOutOfRangeException(sortOrder)
        };

        return result;
    }
}
