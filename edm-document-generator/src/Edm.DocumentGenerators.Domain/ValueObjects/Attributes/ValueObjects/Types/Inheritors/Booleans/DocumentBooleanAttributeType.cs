namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Booleans;

public sealed class DocumentBooleanAttributeType : DocumentAttributeType
{
    private DocumentBooleanAttributeType()
    {
    }

    public static DocumentBooleanAttributeType Instance { get; } = new DocumentBooleanAttributeType();
}
