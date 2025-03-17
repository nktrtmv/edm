using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts;

internal static class SearchValuesApprovalReferencesQueryBffConverter
{
    internal static SearchValuesApprovalReferencesQueryExternal ToExternal(SearchValuesApprovalReferencesQueryBff query)
    {
        var key =
            ApprovalReferenceKeyBffConverter.ToExternal(query.Key);

        string[] ids = query.Ids.ToArray();

        var result = new SearchValuesApprovalReferencesQueryExternal(
            key,
            ids,
            query.Search,
            query.Skip,
            query.Limit);

        return result;
    }
}
