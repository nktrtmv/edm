using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues.Contracts.SearchParams.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues.Contracts.SearchParams;

internal static class SearchValuesApprovalReferencesQueryConverter
{
    internal static DocumentReferenceSearchParamsInternal ToInternal(SearchValuesApprovalReferencesQuery query)
    {
        DocumentReferenceKeyInternal key = ApprovalReferenceKeyConverter.ToInternal(query.Key);

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
