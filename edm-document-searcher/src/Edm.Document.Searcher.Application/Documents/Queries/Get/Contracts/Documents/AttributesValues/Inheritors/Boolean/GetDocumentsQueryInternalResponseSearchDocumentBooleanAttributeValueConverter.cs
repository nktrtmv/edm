using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Booleans;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Boolean;

internal static class GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValueConverter
{
    internal static GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValue FromDomain(SearchDocumentBooleanAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValue(registryRoleId, attributeValue.Values);

        return result;
    }
}
