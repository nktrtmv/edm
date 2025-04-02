using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Numbers;

internal sealed class SearchDocumentNumberAttributeValueInternal : SearchDocumentAttributeValueGenericInternal<Number<SearchDocumentNumberAttributeValueInternal>>
{
    internal SearchDocumentNumberAttributeValueInternal(
        SearchDocumentRegistryRoleInternal registryRole,
        Number<SearchDocumentNumberAttributeValueInternal>[] values,
        int precision)
        : base(registryRole, values)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
