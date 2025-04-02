using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Numbers.Factories;

internal static class SearchDocumentNumberAttributeValueInternalFactory
{
    internal static SearchDocumentNumberAttributeValueInternal CreateFrom(
        SearchDocumentRegistryRoleInternal registryRole,
        params int[] values)
    {
        Number<SearchDocumentNumberAttributeValueInternal>[] numbers = values.Select(NumberConverterFrom<SearchDocumentNumberAttributeValueInternal>.FromInt).ToArray();

        var result = new SearchDocumentNumberAttributeValueInternal(registryRole, numbers, 0);

        return result;
    }
}
