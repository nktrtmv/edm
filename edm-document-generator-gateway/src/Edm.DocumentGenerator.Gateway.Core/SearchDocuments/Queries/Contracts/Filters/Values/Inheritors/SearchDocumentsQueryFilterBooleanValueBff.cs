namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

public sealed class SearchDocumentsQueryFilterBooleanValueBff : SearchDocumentsQueryFilterValueBff
{
    public required bool Value { get; init; }
}
