namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

public sealed class SearchDocumentsQueryFilterDateValueBff : SearchDocumentsQueryFilterValueBff
{
    public required DateTime Value { get; init; }
}
