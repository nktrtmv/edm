using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Dates;

internal static class SearchDocumentDateAttributeValueDbConverter
{
    internal static SearchDocumentDateAttributeValueDb FromDomain(SearchDocumentDateAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        long[] values = attributeValue.Values.Select(UtcDateTimeConverterTo.ToTicks).ToArray();

        var result = new SearchDocumentDateAttributeValueDb
        {
            RegistryRoleId = registryRoleId,
            Values = values
        };

        return result;
    }

    internal static SearchDocumentDateAttributeValue ToDomain(SearchDocumentDateAttributeValueDb attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        UtcDateTime<SearchDocumentDateAttributeValue>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<SearchDocumentDateAttributeValue>.FromTicks).ToArray();

        var result = new SearchDocumentDateAttributeValue(registryRoleId, values);

        return result;
    }
}
