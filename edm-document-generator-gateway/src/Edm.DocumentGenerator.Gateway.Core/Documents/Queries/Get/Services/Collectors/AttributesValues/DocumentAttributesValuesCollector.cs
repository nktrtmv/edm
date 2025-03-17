using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Collectors.AttributesValues;

internal static class DocumentAttributesValuesCollector
{
    internal static IEnumerable<DocumentAttributeValueDetailedDto> Collect(IEnumerable<DocumentAttributeValueDetailedDto> attributesValues)
    {
        foreach (var attributeValue in attributesValues)
        {
            yield return attributeValue;

            if (attributeValue.ValueCase != DocumentAttributeValueDetailedDto.ValueOneofCase.AsTuple)
            {
                continue;
            }

            foreach (var value in attributeValue.AsTuple.Values)
            {
                IEnumerable<DocumentAttributeValueDetailedDto> innerAttributesValues = Collect(value.InnerValues);

                foreach (var innerAttributeValue in innerAttributesValues)
                {
                    yield return innerAttributeValue;
                }
            }
        }
    }
}
