using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Numbers;

internal static class SearchDocumentNumberAttributeValueDbConverter
{
    internal static SearchDocumentNumberAttributeValueDb FromDomain(SearchDocumentNumberAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        long[] values = attributeValue.Values.Select(NumberConverterTo.ToLong).ToArray();

        var result = new SearchDocumentNumberAttributeValueDb
        {
            RegistryRoleId = registryRoleId,
            Values = values
        };

        return result;
    }

    internal static SearchDocumentNumberAttributeValue ToDomain(SearchDocumentNumberAttributeValueDb attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        Number<SearchDocumentNumberAttributeValue>[] values =
            attributeValue.Values.Select(NumberConverterFrom<SearchDocumentNumberAttributeValue>.FromLong).ToArray();

        var result = new SearchDocumentNumberAttributeValue(registryRoleId, values);

        return result;
    }
}
