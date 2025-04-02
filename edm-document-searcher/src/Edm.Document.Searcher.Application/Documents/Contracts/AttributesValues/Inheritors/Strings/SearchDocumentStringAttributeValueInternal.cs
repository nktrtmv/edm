using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;

internal sealed class SearchDocumentStringAttributeValueInternal : SearchDocumentAttributeValueGenericInternal<string>
{
    internal SearchDocumentStringAttributeValueInternal(
        SearchDocumentRegistryRoleInternal registryRole,
        string[] values)
        : base(registryRole, values)
    {
    }
}
