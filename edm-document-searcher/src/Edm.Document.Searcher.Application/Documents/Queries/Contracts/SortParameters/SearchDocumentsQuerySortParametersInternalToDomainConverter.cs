using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Dates;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Strings;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters.Orders;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters.Orders;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters.ValuesTypes;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;

internal static class SearchDocumentsQuerySortParametersInternalToDomainConverter
{
    internal static SearchDocumentSortParameters ToDomain(SearchDocumentsQuerySortParametersInternal sortParameters, SearchDocumentRegistryRoleInternal[] registryRoles)
    {
        int registryRoleId = sortParameters.RegistryRoleId;

        SearchDocumentSortOrder sortOrder = SearchDocumentsQuerySortParametersSortOrderInternalConverter.ToDomain(sortParameters.SortOrder);

        SearchDocumentSortValueType sortValueType = GetSortValueType(sortParameters.RegistryRoleId, registryRoles);

        var result = new SearchDocumentSortParameters(registryRoleId, sortOrder, sortValueType);

        return result;
    }

    private static SearchDocumentSortValueType GetSortValueType(int registryRoleId, SearchDocumentRegistryRoleInternal[] registryRoles)
    {
        SearchDocumentRegistryRoleInternal registryRole = registryRoles.First(r => r.Id == registryRoleId);

        SearchDocumentSortValueType result = registryRole.Type switch
        {
            SearchDocumentBooleanRegistryRoleTypeInternal => SearchDocumentSortValueType.Boolean,
            SearchDocumentDateRegistryRoleTypeInternal => SearchDocumentSortValueType.Date,
            SearchDocumentNumberRegistryRoleTypeInternal => SearchDocumentSortValueType.Number,
            SearchDocumentReferenceRegistryRoleTypeInternal => SearchDocumentSortValueType.Reference,
            SearchDocumentStringRegistryRoleTypeInternal => SearchDocumentSortValueType.String,
            _ => throw new ArgumentTypeOutOfRangeException(registryRole.Type)
        };

        return result;
    }
}
