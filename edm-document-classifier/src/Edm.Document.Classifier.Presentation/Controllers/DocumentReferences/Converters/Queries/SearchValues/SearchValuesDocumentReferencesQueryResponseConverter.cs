using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues.Contracts.Values;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues;

internal static class SearchValuesDocumentReferencesQueryResponseConverter
{
    internal static SearchValuesDocumentReferencesQueryResponse FromInternal(SearchValuesDocumentReferencesQueryResponseInternal response)
    {
        DocumentReferenceValueDto[] values =
            response.Values.Select(DocumentReferenceValueConverter.FromInternal).ToArray();

        var result = new SearchValuesDocumentReferencesQueryResponse
        {
            Values = { values }
        };

        return result;
    }
}
