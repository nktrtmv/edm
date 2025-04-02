using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get.Contracts;

internal static class GetApprovalRuleQueryResponseBffConverter
{
    internal static GetApprovalRuleQueryResponseBff FromDto(GetApprovalRuleQueryResponse response)
    {
        var result = new GetApprovalRuleQueryResponseBff
        {
            Key = EntityTypeKeyBffConverter.FromDto(response.EntityTypeKey),
            DisplayName = response.DisplayName,
            IsReadonly = response.IsReadonly
        };

        return result;
    }
}
