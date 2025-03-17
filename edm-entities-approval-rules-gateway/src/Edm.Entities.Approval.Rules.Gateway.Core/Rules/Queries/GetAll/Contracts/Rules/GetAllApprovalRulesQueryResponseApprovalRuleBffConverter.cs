using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules.Types;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules;

internal static class GetAllApprovalRulesQueryResponseApprovalRuleBffConverter
{
    internal static GetAllApprovalRulesQueryResponseApprovalRuleBff FromDto(GetAllApprovalRulesQueryResponseApprovalRule rule)
    {
        var entityType = EntityTypeSlimBffConverter.FromDto(rule.EntityType);

        var result = new GetAllApprovalRulesQueryResponseApprovalRuleBff
        {
            EntityType = entityType
        };

        return result;
    }
}
