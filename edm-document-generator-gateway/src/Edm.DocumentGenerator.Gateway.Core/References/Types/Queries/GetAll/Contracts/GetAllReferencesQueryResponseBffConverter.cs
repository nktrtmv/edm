using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll.Contracts;

internal static class GetAllReferencesQueryResponseBffConverter
{
    public static GetAllReferencesQueryResponseBff FromDto(GetAllDocumentReferenceTypesQueryResponse response)
    {
        ReferenceTypeBff[] references = response.References.Select(ReferenceTypeBffConverter.FromDto).ToArray();

        var result = new GetAllReferencesQueryResponseBff
        {
            References = references
        };

        return result;
    }
}
