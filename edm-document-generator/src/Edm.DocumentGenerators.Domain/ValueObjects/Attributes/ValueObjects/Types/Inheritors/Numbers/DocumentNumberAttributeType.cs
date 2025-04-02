namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Numbers;

public sealed class DocumentNumberAttributeType : DocumentAttributeType
{
    public DocumentNumberAttributeType(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
