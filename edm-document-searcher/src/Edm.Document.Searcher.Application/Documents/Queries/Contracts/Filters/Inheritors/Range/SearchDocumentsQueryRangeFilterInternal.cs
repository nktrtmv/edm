using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Range;

public sealed record SearchDocumentsQueryRangeFilterInternal(
    int[] RegistryRolesIds,
    SearchDocumentsQueryFilterValueInternal StartValue,
    SearchDocumentsQueryFilterValueInternal EndValue)
    : SearchDocumentsQueryFilterInternal(RegistryRolesIds);
