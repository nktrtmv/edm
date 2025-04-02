using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Tuples;

internal static class DocumentTupleAttributeValueFactory
{
    internal static DocumentAttributeValue CreateDefault(DocumentAttribute attribute)
    {
        TupleInnerValueDocumentAttributeValue[] values = Array.Empty<TupleInnerValueDocumentAttributeValue>();

        var result = new TupleDocumentAttributeValue(attribute, values);

        return result;
    }
}
