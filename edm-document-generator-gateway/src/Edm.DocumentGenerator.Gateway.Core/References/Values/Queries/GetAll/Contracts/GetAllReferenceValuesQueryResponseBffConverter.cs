using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll.Contracts;

internal static class GetAllReferenceValuesQueryResponseBffConverter
{
    public static GetAllReferenceValuesQueryResponseBff FromDto(GetAllDocumentReferenceValuesQueryResponse response)
    {
        ReferenceValueBff[] values = response.Values.Select(ReferenceValueBffConverter.FromDto).ToArray();

        var result = new GetAllReferenceValuesQueryResponseBff
        {
            ReferenceValues = values
        };

        return result;
    }
}
