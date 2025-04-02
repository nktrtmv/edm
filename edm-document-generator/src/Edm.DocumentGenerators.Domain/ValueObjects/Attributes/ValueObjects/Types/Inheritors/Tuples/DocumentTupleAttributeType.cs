namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Tuples;

public sealed class DocumentTupleAttributeType : DocumentAttributeType
{
    private DocumentTupleAttributeType()
    {
    }

    public static DocumentTupleAttributeType Instance { get; } = new DocumentTupleAttributeType();
}
