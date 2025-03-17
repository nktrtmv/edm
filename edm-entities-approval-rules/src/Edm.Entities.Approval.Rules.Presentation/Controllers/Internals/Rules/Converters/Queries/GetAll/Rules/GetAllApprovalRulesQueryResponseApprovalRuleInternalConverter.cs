using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetAll.EntityTypes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetAll.Rules;

internal static class GetAllApprovalRulesQueryResponseApprovalRuleInternalConverter
{
    internal static GetAllApprovalRulesQueryResponseApprovalRule ToDto(GetAllApprovalRulesQueryResponseApprovalRuleInternal rule)
    {
        GetAllApprovalRulesQueryResponseEntityTypeDto entityType = GetAllApprovalRulesQueryResponseEntityTypeInternalConverter.ToDto(rule.EntityType);

        var result = new GetAllApprovalRulesQueryResponseApprovalRule
        {
            EntityType = entityType
        };

        return result;
    }
}
