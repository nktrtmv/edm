namespace Edm.Document.Classifier.Application.Contracts.Documents.Attributes.Types.Inheritors.Boolean;

public sealed class BooleanDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    internal static readonly BooleanDocumentAttributeTypeInternal Instance = new BooleanDocumentAttributeTypeInternal();

    private BooleanDocumentAttributeTypeInternal()
    {
    }
}
