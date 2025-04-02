namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

public sealed class SearchDocumentsQueryFilterNumberValueBff : SearchDocumentsQueryFilterValueBff
{
    public required long Value { get; init; }
}
