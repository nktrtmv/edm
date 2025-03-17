using Edm.Document.Classifier.Application.DocumentReferences.Types.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetAll.Contracts;

internal static class GetAllDocumentReferenceTypesQueryResponseInternalConverter
{
    public static GetAllDocumentReferenceTypesQueryResponseInternal FromDomain(ReferenceType[] referenceTypes)
    {
        DocumentReferenceTypeResponseInternal[] references = referenceTypes.Select(DocumentReferenceTypeResponseInternalConverter.FromDomain).ToArray();

        var result = new GetAllDocumentReferenceTypesQueryResponseInternal(references);

        return result;
    }
}
