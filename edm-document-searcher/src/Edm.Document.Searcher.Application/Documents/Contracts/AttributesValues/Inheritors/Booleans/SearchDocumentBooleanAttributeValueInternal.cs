using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Booleans;

internal sealed class SearchDocumentBooleanAttributeValueInternal : SearchDocumentAttributeValueGenericInternal<bool>
{
    internal SearchDocumentBooleanAttributeValueInternal(
        SearchDocumentRegistryRoleInternal registryRole,
        bool[] values)
        : base(registryRole, values)
    {
    }
}
