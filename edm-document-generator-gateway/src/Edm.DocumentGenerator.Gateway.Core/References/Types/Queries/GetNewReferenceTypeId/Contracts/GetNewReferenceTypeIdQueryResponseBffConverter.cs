using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId.Contracts;

public static class GetNewReferenceTypeIdQueryResponseBffConverter
{
    public static GetNewReferenceTypeIdQueryResponseBff FromDto(GetNewReferenceTypeIdQueryResponse response)
    {
        var result = new GetNewReferenceTypeIdQueryResponseBff
        {
            ReferenceType = response.ReferenceType
        };

        return result;
    }
}
