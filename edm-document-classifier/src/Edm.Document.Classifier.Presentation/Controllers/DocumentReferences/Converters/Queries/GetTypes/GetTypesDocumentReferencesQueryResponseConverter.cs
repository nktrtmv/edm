using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.GetTypes.Contracts.Types;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.GetTypes;

internal static class GetTypesDocumentReferencesQueryResponseConverter
{
    internal static GetTypesDocumentReferencesQueryResponse FromInternal(GetTypesDocumentReferencesQueryResponseInternal response)
    {
        DocumentReferenceTypeDto[] types =
            response.Types.Select(DocumentReferenceTypeConverter.ToDto).ToArray();

        var result = new GetTypesDocumentReferencesQueryResponse
        {
            Types_ = { types }
        };

        return result;
    }
}
