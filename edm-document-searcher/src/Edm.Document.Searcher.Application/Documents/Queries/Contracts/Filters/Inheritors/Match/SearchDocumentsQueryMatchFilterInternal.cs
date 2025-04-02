using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Match;

public sealed record SearchDocumentsQueryMatchFilterInternal(
    int[] RegistryRolesIds,
    SearchDocumentsQueryFilterValueInternal[] Values) : SearchDocumentsQueryFilterInternal(RegistryRolesIds);
