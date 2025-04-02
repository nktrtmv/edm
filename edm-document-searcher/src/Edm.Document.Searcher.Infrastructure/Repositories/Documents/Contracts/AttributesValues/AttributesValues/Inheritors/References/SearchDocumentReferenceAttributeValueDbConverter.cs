using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.References;

internal static class SearchDocumentReferenceAttributeValueDbConverter
{
    internal static SearchDocumentReferenceAttributeValueDb FromDomain(SearchDocumentReferenceAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new SearchDocumentReferenceAttributeValueDb
        {
            RegistryRoleId = registryRoleId,
            Values = attributeValue.Values,
            ReferenceType = attributeValue.ReferenceType,
            SearchDocumentParent =
                attributeValue.ParentReferenceTypeAttributeValue?.Select(SearchDocumentParentReferenceAttributeValueDbConverter.FromDomain).ToList()
        };

        return result;
    }

    internal static SearchDocumentReferenceAttributeValue ToDomain(SearchDocumentReferenceAttributeValueDb attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new SearchDocumentReferenceAttributeValue(
            registryRoleId,
            attributeValue.Values,
            attributeValue.ReferenceType,
            attributeValue.SearchDocumentParent?
                .Select(SearchDocumentParentReferenceAttributeValueDbConverter.ToDomain)
                .ToList());

        return result;
    }
}
