using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get.Contracts;

internal static class GetReferenceQueryResponseBffConverter
{
    public static GetReferenceQueryResponseBff FromDto(GetDocumentReferenceTypeQueryResponse response)
    {
        var reference = ReferenceTypeBffConverter.FromDto(response.Reference);

        var result = new GetReferenceQueryResponseBff
        {
            Reference = reference
        };

        return result;
    }
}
