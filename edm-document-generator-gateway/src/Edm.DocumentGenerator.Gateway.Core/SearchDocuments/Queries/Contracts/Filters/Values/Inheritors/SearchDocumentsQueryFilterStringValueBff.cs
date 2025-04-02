namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

public sealed class SearchDocumentsQueryFilterStringValueBff : SearchDocumentsQueryFilterValueBff
{
    public required string Value { get; init; }
}
