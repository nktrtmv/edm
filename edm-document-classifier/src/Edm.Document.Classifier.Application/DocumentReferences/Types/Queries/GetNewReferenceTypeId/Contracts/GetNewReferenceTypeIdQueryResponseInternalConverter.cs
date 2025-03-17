using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetNewReferenceTypeId.Contracts;

public static class GetNewReferenceTypeIdQueryResponseInternalConverter
{
    public static GetNewReferenceTypeIdQueryResponseInternal FromDomain(int newReferenceTypeId)
    {
        Id<DocumentReferenceTypeId> referenceType = IdConverterFrom<DocumentReferenceTypeId>.FromInt(newReferenceTypeId);

        var result = new GetNewReferenceTypeIdQueryResponseInternal(referenceType);

        return result;
    }
}
