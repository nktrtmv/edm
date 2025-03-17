using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Number;

internal static class GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValueConverter
{
    internal static GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue FromDomain(SearchDocumentNumberAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        Number<GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue>[] values =
            attributeValue.Values.Select(NumberConverterFrom<GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue>.From).ToArray();

        var result = new GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue(registryRoleId, values);

        return result;
    }
}
