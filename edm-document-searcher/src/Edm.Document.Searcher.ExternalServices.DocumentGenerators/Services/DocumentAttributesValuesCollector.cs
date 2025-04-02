using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Services;

internal static class DocumentAttributesValuesCollector
{
    internal static IEnumerable<DocumentAttributeValueDetailedDto> Collect(IEnumerable<DocumentAttributeValueDetailedDto> attributesValues)
    {
        foreach (DocumentAttributeValueDetailedDto attributeValue in attributesValues)
        {
            yield return attributeValue;

            if (attributeValue.AsTuple is null)
            {
                continue;
            }

            foreach (DocumentTupleAttributeValueInnerValueDetailedDto value in attributeValue.AsTuple.Values)
            {
                IEnumerable<DocumentAttributeValueDetailedDto> innerAttributesValues = Collect(value.InnerValues);

                foreach (DocumentAttributeValueDetailedDto innerAttributeValue in innerAttributesValues)
                {
                    yield return innerAttributeValue;
                }
            }
        }
    }
}
