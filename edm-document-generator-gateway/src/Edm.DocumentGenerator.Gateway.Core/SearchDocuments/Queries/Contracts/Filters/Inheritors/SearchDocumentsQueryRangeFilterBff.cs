using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;

public sealed class SearchDocumentsQueryRangeFilterBff : SearchDocumentsQueryFilterBff
{
    public required SearchDocumentsQueryFilterValueBff StartValue { get; init; }
    public required SearchDocumentsQueryFilterValueBff EndValue { get; init; }
}
