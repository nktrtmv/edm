using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.GetTypes.Contracts.Types;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.GetTypes;

internal static class GetTypesApprovalReferencesQueryResponseExternalConverter
{
    internal static GetTypesApprovalReferencesQueryResponseExternal FromDto(GetTypesApprovalReferencesQueryResponse response)
    {
        ApprovalReferenceTypeExternal[] types =
            response.Types_.Select(ApprovalReferenceTypeExternalConverter.FromDto).ToArray();

        var result = new GetTypesApprovalReferencesQueryResponseExternal(types);

        return result;
    }
}
