using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues;

internal static class SearchValuesApprovalReferencesQueryExternalConverter
{
    internal static SearchValuesApprovalReferencesQuery ToDto(SearchValuesApprovalReferencesQueryExternal query)
    {
        var key = ApprovalReferenceKeyExternalConverter.ToDto(query.Key);

        string[] ids = query.Ids.ToArray();

        var result = new SearchValuesApprovalReferencesQuery
        {
            Key = key,
            Ids = { ids },
            Search = query.Search,
            Skip = query.Skip,
            Limit = query.Limit
        };

        return result;
    }
}
