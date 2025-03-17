using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Abstractions;

internal abstract class SearchDocumentAttributeValueGenericInternal<T>(SearchDocumentRegistryRoleInternal registryRole, T[] values)
    : SearchDocumentAttributeValueInternal(registryRole)
{
    public T[] Values { get; } = values;
}
