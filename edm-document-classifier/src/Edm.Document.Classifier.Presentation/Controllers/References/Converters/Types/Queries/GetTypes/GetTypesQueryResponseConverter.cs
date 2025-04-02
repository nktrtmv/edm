using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetTypes.Contracts.References;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetTypes;

internal static class GetTypesQueryResponseConverter
{
    internal static GetTypesQueryResponse FromInternal(GetTypesDocumentReferencesQueryResponseInternal response)
    {
        GetTypesQueryResponseReference[] references =
            response.Types.Select(GetTypesQueryResponseReferenceConverter.FromInternal).ToArray();

        var result = new GetTypesQueryResponse
        {
            References = { references }
        };

        return result;
    }
}
