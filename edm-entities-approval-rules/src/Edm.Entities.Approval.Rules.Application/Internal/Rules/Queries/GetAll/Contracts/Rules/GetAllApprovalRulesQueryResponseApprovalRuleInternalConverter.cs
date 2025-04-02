using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules.Types;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules;

internal static class GetAllApprovalRulesQueryResponseApprovalRuleInternalConverter
{
    internal static GetAllApprovalRulesQueryResponseApprovalRuleInternal FromDomain(ApprovalRule approvalRule)
    {
        GetAllApprovalRulesQueryResponseEntityTypeInternal entityType = EntityTypeSlimInternalConverter.FromDomain(approvalRule);

        var result = new GetAllApprovalRulesQueryResponseApprovalRuleInternal(entityType);

        return result;
    }
}
