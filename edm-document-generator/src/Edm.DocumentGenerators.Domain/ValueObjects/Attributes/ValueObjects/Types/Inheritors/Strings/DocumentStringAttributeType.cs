namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Strings;

public sealed class DocumentStringAttributeType : DocumentAttributeType
{
    private DocumentStringAttributeType()
    {
    }

    public static DocumentStringAttributeType Instance { get; } = new DocumentStringAttributeType();
}
