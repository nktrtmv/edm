using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;

public sealed class SearchDocumentsQueryMatchFilterBff : SearchDocumentsQueryFilterBff
{
    public required SearchDocumentsQueryFilterValueBff[] Values { get; init; }
}
