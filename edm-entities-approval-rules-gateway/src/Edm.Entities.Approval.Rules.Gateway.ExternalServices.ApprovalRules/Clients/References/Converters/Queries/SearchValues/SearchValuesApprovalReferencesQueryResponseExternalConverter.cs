using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues;

internal static class SearchValuesApprovalReferencesQueryResponseExternalConverter
{
    internal static SearchValuesApprovalReferencesQueryResponseExternal FromDto(
        SearchValuesApprovalReferencesQueryResponse response,
        ApprovalReferenceKeyExternal key)
    {
        ApprovalReferenceValueExternal[] values =
            response.Values.Select(ApprovalReferenceValueExternalConverter.FromDto).ToArray();

        var result = new SearchValuesApprovalReferencesQueryResponseExternal(key, values);

        return result;
    }
}
