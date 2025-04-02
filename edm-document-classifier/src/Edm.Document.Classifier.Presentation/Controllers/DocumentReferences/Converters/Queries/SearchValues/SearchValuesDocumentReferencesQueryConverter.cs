using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues;

internal static class SearchValuesDocumentReferencesQueryConverter
{
    internal static SearchValuesDocumentReferencesQueryInternal ToInternal(SearchValuesDocumentReferencesQuery query)
    {
        DocumentReferenceSearchParamsInternal searchParams =
            Contracts.SearchParams.SearchValuesDocumentReferencesQueryConverter.ToInternal(query);

        var result = new SearchValuesDocumentReferencesQueryInternal(searchParams);

        return result;
    }
}
