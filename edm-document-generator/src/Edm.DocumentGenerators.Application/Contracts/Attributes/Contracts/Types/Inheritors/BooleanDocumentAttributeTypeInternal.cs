namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types.Inheritors;

public sealed record BooleanDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    private BooleanDocumentAttributeTypeInternal()
    {
    }

    public static BooleanDocumentAttributeTypeInternal Instance { get; } = new BooleanDocumentAttributeTypeInternal();
}
