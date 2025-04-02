using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetNewReferenceTypeId.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetNewReferenceTypeId;

internal static class GetNewReferenceTypeIdQueryResponseConverter
{
    public static GetNewReferenceTypeIdQueryResponse FromInternal(GetNewReferenceTypeIdQueryResponseInternal response)
    {
        string referenceType = ReferenceTypeIdConverter.ToDto(response.ReferenceTypeId);

        var result = new GetNewReferenceTypeIdQueryResponse
        {
            ReferenceType = referenceType
        };

        return result;
    }
}
