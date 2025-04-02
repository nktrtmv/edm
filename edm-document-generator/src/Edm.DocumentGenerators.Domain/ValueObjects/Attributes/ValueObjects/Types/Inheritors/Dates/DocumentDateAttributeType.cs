namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Dates;

public sealed class DocumentDateAttributeType : DocumentAttributeType
{
    private DocumentDateAttributeType()
    {
    }

    public static DocumentDateAttributeType Instance { get; } = new DocumentDateAttributeType();
}
