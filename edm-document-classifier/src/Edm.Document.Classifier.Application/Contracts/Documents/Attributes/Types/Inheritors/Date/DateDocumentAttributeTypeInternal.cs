namespace Edm.Document.Classifier.Application.Contracts.Documents.Attributes.Types.Inheritors.Date;

public sealed class DateDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    internal static readonly DateDocumentAttributeTypeInternal Instance = new DateDocumentAttributeTypeInternal();

    private DateDocumentAttributeTypeInternal()
    {
    }
}
