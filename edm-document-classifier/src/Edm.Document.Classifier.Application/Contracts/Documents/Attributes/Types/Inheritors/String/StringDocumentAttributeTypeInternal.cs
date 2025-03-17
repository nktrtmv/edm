namespace Edm.Document.Classifier.Application.Contracts.Documents.Attributes.Types.Inheritors.String;

public sealed class StringDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    internal static readonly StringDocumentAttributeTypeInternal Instance = new StringDocumentAttributeTypeInternal();

    private StringDocumentAttributeTypeInternal()
    {
    }
}
