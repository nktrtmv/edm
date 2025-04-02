using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts;

internal static class GetAllApprovalGraphsQueryBffConverter
{
    internal static GetAllApprovalGraphsQuery ToDto(GetAllApprovalGraphsQueryBff query)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(query.ApprovalRuleKey);

        var result = new GetAllApprovalGraphsQuery
        {
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
