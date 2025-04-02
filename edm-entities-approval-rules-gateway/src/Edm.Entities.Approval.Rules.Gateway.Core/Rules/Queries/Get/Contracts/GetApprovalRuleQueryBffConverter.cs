using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get.Contracts;

internal static class GetApprovalRuleQueryBffConverter
{
    internal static GetApprovalRuleQuery ToDto(GetApprovalRuleQueryBff query)
    {
        var entityTypeKey = EntityTypeKeyBffConverter.ToDto(query.EntityTypeKey);

        var result = new GetApprovalRuleQuery
        {
            EntityTypeKey = entityTypeKey
        };

        return result;
    }
}
