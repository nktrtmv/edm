using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Reference;

internal static class GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValueConverter
{
    internal static GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValue FromDomain(SearchDocumentReferenceAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValue(
            registryRoleId,
            attributeValue.Values,
            attributeValue.ReferenceType,
            attributeValue.ParentReferenceTypeAttributeValue
                ?.Select(GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValueConverter.FromDomain)
                .ToList());

        return result;
    }
}
