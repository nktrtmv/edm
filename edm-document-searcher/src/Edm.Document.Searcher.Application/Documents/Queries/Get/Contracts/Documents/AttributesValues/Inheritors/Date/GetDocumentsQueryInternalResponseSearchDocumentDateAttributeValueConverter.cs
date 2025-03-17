using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Date;

internal static class GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValueConverter
{
    internal static GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue FromDomain(SearchDocumentDateAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        UtcDateTime<GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue>.From).ToArray();

        var result = new GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue(registryRoleId, values);

        return result;
    }
}
