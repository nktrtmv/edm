using Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists;

public abstract class FixedListDocumentReferenceBaseService : DocumentReferenceService
{
    internal static DocumentReferenceValue[] Search(DocumentReferenceValue[] values, DocumentReferenceSearchParamsInternal searchParams)
    {
        IEnumerable<DocumentReferenceValue> result;

        if (searchParams.Ids.Length != 0)
        {
            result = values.Where(v => searchParams.Ids.Contains(v.Id));
        }
        else
        {
            result = values
                .Where(v => QueryMatcher.ContainsNullOrEmptyQuery(searchParams.Search, v.DisplayValue, v.DisplaySubValue))
                .Skip(searchParams.Skip)
                .Take(searchParams.Limit);
        }

        return result.ToArray();
    }
}
