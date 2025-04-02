namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types.Inheritors;

public sealed record DateDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    private DateDocumentAttributeTypeInternal()
    {
    }

    public static DateDocumentAttributeTypeInternal Instance { get; } = new DateDocumentAttributeTypeInternal();
}
