using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues;

internal static class SearchValuesApprovalReferencesQueryResponseConverter
{
    internal static SearchValuesApprovalReferencesQueryResponse FromInternal(SearchValuesDocumentReferencesQueryResponseInternal response)
    {
        ApprovalReferenceValueDto[] values =
            response.Values.Select(ApprovalReferenceValueConverter.FromInternal).ToArray();

        var result = new SearchValuesApprovalReferencesQueryResponse
        {
            Values = { values }
        };

        return result;
    }
}
