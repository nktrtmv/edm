using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;

public sealed record SearchDocumentsQueryContainsFilter(
    int[] RegistryRolesIds,
    SearchDocumentsQueryFilterValue[] Values) : SearchDocumentsQueryFilter(RegistryRolesIds);
