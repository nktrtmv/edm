using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Contains;

public sealed record SearchDocumentsQueryContainsFilterInternal(
    int[] RegistryRolesIds,
    SearchDocumentsQueryFilterValueInternal[] Values) : SearchDocumentsQueryFilterInternal(RegistryRolesIds);
