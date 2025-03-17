using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts.Types;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts;

internal static class GetTypesApprovalReferencesQueryResponseBffConverter
{
    internal static GetTypesApprovalReferencesQueryResponseBff FromExternal(GetTypesApprovalReferencesQueryResponseExternal response)
    {
        ApprovalReferenceTypeBff[] types = response.Types.Select(ApprovalReferenceTypeBffConverter.FromExternal).ToArray();

        var result = new GetTypesApprovalReferencesQueryResponseBff
        {
            Types = types
        };

        return result;
    }
}
