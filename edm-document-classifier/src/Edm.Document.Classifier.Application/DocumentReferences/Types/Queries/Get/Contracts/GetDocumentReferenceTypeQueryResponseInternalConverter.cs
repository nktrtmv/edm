using Edm.Document.Classifier.Application.DocumentReferences.Types.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.Get.Contracts;

internal static class GetDocumentReferenceTypeQueryResponseInternalConverter
{
    public static GetDocumentReferenceTypeQueryResponseInternal FromDomain(ReferenceType referenceDb)
    {
        DocumentReferenceTypeResponseInternal reference = DocumentReferenceTypeResponseInternalConverter.FromDomain(referenceDb);

        var result = new GetDocumentReferenceTypeQueryResponseInternal(reference);

        return result;
    }
}
