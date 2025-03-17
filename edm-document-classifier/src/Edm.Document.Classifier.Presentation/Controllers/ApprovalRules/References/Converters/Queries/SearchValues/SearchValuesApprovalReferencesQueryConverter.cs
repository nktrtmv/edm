using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues;

internal static class SearchValuesApprovalReferencesQueryConverter
{
    internal static SearchValuesDocumentReferencesQueryInternal ToInternal(SearchValuesApprovalReferencesQuery query)
    {
        DocumentReferenceSearchParamsInternal searchParams =
            Contracts.SearchParams.SearchValuesApprovalReferencesQueryConverter.ToInternal(query);

        var result = new SearchValuesDocumentReferencesQueryInternal(searchParams);

        return result;
    }
}
