using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Collectors;

public static class DocumentAttributesValuesCollector
{
    public static IEnumerable<DocumentAttributeValue> Collect(DocumentAttributeValue[] attributesValues)
    {
        foreach (DocumentAttributeValue attributeValue in attributesValues)
        {
            yield return attributeValue;

            if (attributeValue is not TupleDocumentAttributeValue tupleAttributeValue)
            {
                continue;
            }

            foreach (TupleInnerValueDocumentAttributeValue value in tupleAttributeValue.Values)
            {
                IEnumerable<DocumentAttributeValue> innerAttributesValues = Collect(value.InnerValues);

                foreach (DocumentAttributeValue innerAttributeValue in innerAttributesValues)
                {
                    yield return innerAttributeValue;
                }
            }
        }
    }
}
