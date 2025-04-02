using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Collectors.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Collectors;

internal static class DocumentAttributesFrontMetadataCollector
{
    internal static Dictionary<string, string> Collect(DocumentDetailedDto document)
    {
        DocumentAttributeDto[] attributes = DocumentAttributesCollector
            .Collect(document.AttributesValues.Select(v => v.Attribute))
            .ToArray();

        var result = new Dictionary<string, string>();

        foreach (var attribute in attributes)
        {
            result[attribute.Data.Id] = attribute.Data.FrontMetadata;
        }

        return result;
    }
}
