using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get.Contracts;

internal static class GetReferenceValueQueryResponseBffConverter
{
    public static GetReferenceValueQueryResponseBff FromDto(GetDocumentReferenceValueQueryResponse response)
    {
        var value = ReferenceValueBffConverter.FromDto(response.Value);

        var result = new GetReferenceValueQueryResponseBff
        {
            ReferenceValue = value
        };

        return result;
    }
}
