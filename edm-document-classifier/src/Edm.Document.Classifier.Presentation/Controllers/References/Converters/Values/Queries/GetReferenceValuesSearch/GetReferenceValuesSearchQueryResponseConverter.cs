using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetReferenceValuesSearch.Contracts.Values;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetReferenceValuesSearch;

internal static class GetReferenceValuesSearchQueryResponseConverter
{
    internal static GetReferenceValuesSearchQueryResponse FromInternal(SearchValuesDocumentReferencesQueryResponseInternal response)
    {
        ReferenceValueDto[] referenceValues =
            response.Values.Select(ReferenceValueDtoConverter.FromInternal).ToArray();

        var result = new GetReferenceValuesSearchQueryResponse
        {
            ReferenceValues = { referenceValues }
        };

        return result;
    }
}
