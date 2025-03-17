namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types.Inheritors;

public sealed record TupleDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    private TupleDocumentAttributeTypeInternal()
    {
    }

    public static TupleDocumentAttributeTypeInternal Instance { get; } = new TupleDocumentAttributeTypeInternal();
}
