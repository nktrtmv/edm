using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;

public sealed record SearchDocumentsQueryMatchFilter(
    int[] RegistryRolesIds,
    SearchDocumentsQueryFilterValue[] Values) : SearchDocumentsQueryFilter(RegistryRolesIds);
