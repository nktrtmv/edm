using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;

namespace Edm.Document.Classifier.Application.Contracts.Documents.Attributes.Types.Inheritors.Reference;

public sealed class ReferenceDocumentAttributeTypeInternal : DocumentAttributeTypeInternal
{
    internal ReferenceDocumentAttributeTypeInternal(DocumentReferenceTypeId referenceTypeId)
    {
        ReferenceTypeId = referenceTypeId;
    }

    public DocumentReferenceTypeId ReferenceTypeId { get; }
}
