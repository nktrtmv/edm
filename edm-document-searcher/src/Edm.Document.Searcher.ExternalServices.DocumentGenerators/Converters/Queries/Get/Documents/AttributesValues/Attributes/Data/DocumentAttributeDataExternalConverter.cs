using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues.Attributes.Data;

internal static class DocumentAttributeDataExternalConverter
{
    internal static DocumentAttributeDataExternal FromDto(DocumentAttributeDataDto data)
    {
        int[] registryRolesIds =
            data.RegistryRoles.ToArray();

        int[] documentRolesIds =
            data.DocumentsRoles.ToArray();

        var result = new DocumentAttributeDataExternal(data.Id, data.IsArray, registryRolesIds, data.SystemName, data.DisplayName, documentRolesIds);

        return result;
    }
}
