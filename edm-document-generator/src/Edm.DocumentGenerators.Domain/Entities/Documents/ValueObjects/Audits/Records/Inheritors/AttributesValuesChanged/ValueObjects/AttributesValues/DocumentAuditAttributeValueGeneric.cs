using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;

public abstract record DocumentAuditAttributeValueGeneric<T>(Id<DocumentAttribute> Id, T[] Values) : DocumentAuditAttributeValue(Id)
{
    public T[] Values { get; private set; } = Values;

    public void SetValues(T[] values)
    {
        Values = values;
    }
}
