using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;

internal sealed class SearchDocumentReferenceAttributeValueInternal : SearchDocumentAttributeValueGenericInternal<string>
{
    internal SearchDocumentReferenceAttributeValueInternal(
        SearchDocumentRegistryRoleInternal registryRole,
        string[] values,
        string referenceType,
        List<ParentReferenceTypeAttributeValueInternal>? parentReference = null)
        : base(registryRole, values)
    {
        ReferenceType = referenceType;
        ParentReference = parentReference;
    }

    public string ReferenceType { get; }

    public List<ParentReferenceTypeAttributeValueInternal>? ParentReference { get; }
}

internal record ParentReferenceTypeAttributeValueInternal(string ReferenceType, string[] Values);
