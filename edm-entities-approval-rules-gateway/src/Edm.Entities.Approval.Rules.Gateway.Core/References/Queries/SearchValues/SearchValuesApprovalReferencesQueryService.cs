using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues;

public sealed class SearchValuesApprovalReferencesQueryService : ApprovalReferencesServiceBase
{
    public SearchValuesApprovalReferencesQueryService(IApprovalReferencesClient references) : base(references)
    {
    }

    public async Task<SearchValuesApprovalReferencesQueryResponseBff> SearchValues(SearchValuesApprovalReferencesQueryBff query, CancellationToken cancellationToken)
    {
        var request = SearchValuesApprovalReferencesQueryBffConverter.ToExternal(query);

        var response = await References.SearchValues(request, cancellationToken);

        var result = SearchValuesApprovalReferencesQueryResponseBffConverter.FromExternal(response);

        return result;
    }
}
