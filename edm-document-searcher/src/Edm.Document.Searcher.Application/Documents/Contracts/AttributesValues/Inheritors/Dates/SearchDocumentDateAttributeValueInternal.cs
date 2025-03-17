using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Dates;

internal sealed class SearchDocumentDateAttributeValueInternal : SearchDocumentAttributeValueGenericInternal<UtcDateTime<SearchDocumentDateAttributeValueInternal>>
{
    internal SearchDocumentDateAttributeValueInternal(
        SearchDocumentRegistryRoleInternal registryRole,
        UtcDateTime<SearchDocumentDateAttributeValueInternal>[] values)
        : base(registryRole, values)
    {
    }
}
