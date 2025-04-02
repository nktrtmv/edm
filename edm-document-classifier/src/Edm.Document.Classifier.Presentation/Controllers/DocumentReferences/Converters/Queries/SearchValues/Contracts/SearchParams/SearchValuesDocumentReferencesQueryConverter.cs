using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues.Contracts.SearchParams.Keys;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues.Contracts.SearchParams;

internal static class SearchValuesDocumentReferencesQueryConverter
{
    internal static DocumentReferenceSearchParamsInternal ToInternal(SearchValuesDocumentReferencesQuery query)
    {
        DocumentReferenceKeyInternal key = DocumentReferenceKeyDtoConverter.ToInternal(query.Key);

        string[] ids = query.Ids.ToArray();

        var result = new DocumentReferenceSearchParamsInternal(
            key,
            ids,
            query.Search,
            query.Skip,
            query.Limit);

        return result;
    }
}
