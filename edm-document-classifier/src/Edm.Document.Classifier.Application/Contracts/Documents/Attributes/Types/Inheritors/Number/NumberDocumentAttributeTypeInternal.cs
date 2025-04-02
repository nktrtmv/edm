namespace Edm.Document.Classifier.Application.Contracts.Documents.Attributes.Types.Inheritors.Number;

public sealed class NumberDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    public NumberDocumentAttributeTypeInternal(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
