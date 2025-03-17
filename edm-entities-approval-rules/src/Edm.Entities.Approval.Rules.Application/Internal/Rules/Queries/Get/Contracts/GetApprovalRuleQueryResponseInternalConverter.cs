using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get.Contracts;

internal static class GetApprovalRuleQueryResponseInternalConverter
{
    internal static GetApprovalRuleQueryResponseInternal FromDomain(ApprovalRule rule)
    {
        EntityTypeKeyInternal key = EntityTypeKeyInternalConverter.FromDomain(rule.EntityType.Key);

        var result = new GetApprovalRuleQueryResponseInternal(key, rule.EntityType.DisplayName, rule.IsDeleted);

        return result;
    }
}
