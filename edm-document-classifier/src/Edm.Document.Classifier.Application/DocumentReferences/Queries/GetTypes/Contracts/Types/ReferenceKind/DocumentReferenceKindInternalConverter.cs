using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;

namespace Edm.Document.Classifier.Application.DocumentReferences.Queries.GetTypes.Contracts.Types.ReferenceKind;

public static class DocumentReferenceKindInternalConverter
{
    internal static DocumentReferenceKindInternal FromDomain(DocumentReferenceKind referenceKind)
    {
        DocumentReferenceKindInternal result = referenceKind switch
        {
            DocumentReferenceKind.Employee => DocumentReferenceKindInternal.Employee,
            _ => DocumentReferenceKindInternal.None
        };

        return result;
    }
}
