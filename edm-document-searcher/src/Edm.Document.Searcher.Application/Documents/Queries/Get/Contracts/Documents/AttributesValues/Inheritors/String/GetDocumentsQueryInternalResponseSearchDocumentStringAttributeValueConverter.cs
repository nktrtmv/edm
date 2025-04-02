using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Strings;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.String;

internal static class GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValueConverter
{
    internal static GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValue FromDomain(SearchDocumentStringAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValue(registryRoleId, attributeValue.Values);

        return result;
    }
}
