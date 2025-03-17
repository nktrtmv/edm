using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.GetTypes;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References;

internal sealed class ApprovalReferencesClient : IApprovalReferencesClient
{
    public ApprovalReferencesClient(ApprovalReferencesService.ApprovalReferencesServiceClient references)
    {
        References = references;
    }

    private ApprovalReferencesService.ApprovalReferencesServiceClient References { get; }

    async Task<GetTypesApprovalReferencesQueryResponseExternal> IApprovalReferencesClient.GetTypes(
        GetTypesApprovalReferencesQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request = new GetTypesApprovalReferencesQuery();

        var response = await References.GetTypesAsync(request, cancellationToken: cancellationToken);

        var result = GetTypesApprovalReferencesQueryResponseExternalConverter.FromDto(response);

        return result;
    }

    async Task<SearchValuesApprovalReferencesQueryResponseExternal> IApprovalReferencesClient.SearchValues(
        SearchValuesApprovalReferencesQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request = SearchValuesApprovalReferencesQueryExternalConverter.ToDto(query);

        var response = await References.SearchValuesAsync(request, cancellationToken: cancellationToken);

        var result = SearchValuesApprovalReferencesQueryResponseExternalConverter.FromDto(response, query.Key);

        return result;
    }
}
