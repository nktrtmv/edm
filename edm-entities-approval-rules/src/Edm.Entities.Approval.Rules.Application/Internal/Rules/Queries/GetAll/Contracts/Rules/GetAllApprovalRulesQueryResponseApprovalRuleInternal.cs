using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules.Types;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules;

public sealed class GetAllApprovalRulesQueryResponseApprovalRuleInternal
{
    public GetAllApprovalRulesQueryResponseApprovalRuleInternal(GetAllApprovalRulesQueryResponseEntityTypeInternal entityType)
    {
        EntityType = entityType;
    }

    public GetAllApprovalRulesQueryResponseEntityTypeInternal EntityType { get; }
}
