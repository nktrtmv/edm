using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Collectors.Attributes;

internal static class DocumentAttributesCollector
{
    internal static IEnumerable<DocumentAttributeDto> Collect(IEnumerable<DocumentAttributeDto> attributes)
    {
        foreach (var attribute in attributes)
        {
            yield return attribute;

            if (attribute.ValueCase is not DocumentAttributeDto.ValueOneofCase.AsTuple)
            {
                continue;
            }

            foreach (var innerAttribute in Collect(attribute.AsTuple.InnerAttributes))
            {
                yield return innerAttribute;
            }
        }
    }
}
