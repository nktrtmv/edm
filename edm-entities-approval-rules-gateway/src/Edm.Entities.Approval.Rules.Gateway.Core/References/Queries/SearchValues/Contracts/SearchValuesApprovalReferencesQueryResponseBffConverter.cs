using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts;

internal static class SearchValuesApprovalReferencesQueryResponseBffConverter
{
    internal static SearchValuesApprovalReferencesQueryResponseBff FromExternal(SearchValuesApprovalReferencesQueryResponseExternal response)
    {
        ApprovalReferenceValueBff[] values =
            response.Values.Select(ApprovalReferenceValueBffConverter.FromExternal).ToArray();

        var result = new SearchValuesApprovalReferencesQueryResponseBff
        {
            Values = values
        };

        return result;
    }
}
