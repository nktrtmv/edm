namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types.Inheritors;

public sealed record StringDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    private StringDocumentAttributeTypeInternal()
    {
    }

    public static StringDocumentAttributeTypeInternal Instance { get; } = new StringDocumentAttributeTypeInternal();
}
