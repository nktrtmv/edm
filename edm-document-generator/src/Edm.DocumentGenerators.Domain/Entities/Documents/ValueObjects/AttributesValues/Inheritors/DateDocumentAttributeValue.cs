using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;

public sealed class DateDocumentAttributeValue : DocumentAttributeValueGeneric<UtcDateTime<DateDocumentAttributeValue>>
{
    public DateDocumentAttributeValue(DocumentAttribute attribute, UtcDateTime<DateDocumentAttributeValue>[] values) : base(attribute, values)
    {
    }
}
